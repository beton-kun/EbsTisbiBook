using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EbsTisbiBook.WebAppMVC.Models;
using EbsTisbiBook.WebAppMVC.Models.Library;
using EbsTisbiBook.WebAppMVC.Models.Library.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Korzh.EasyQuery.Linq;

namespace EbsTisbiBook.WebAppMVC.Controllers.Books
{
    public class BooksController : Controller
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext libraryContext)
        {
            _context = libraryContext;
        }

        public async Task<IActionResult> List(int? pubhouse, int? pubyearMin, int? pubyearMax, int? author, string searchText, int page = 1,
            BooksSortState sortOrder = BooksSortState.PubyearAsc)
        {
            var pageSize = 3;   // количество элементов на странице

            //  фильтрация
            IQueryable<Book> books = _context.Books.Include(b => b.Pubhouse);

            if (pubhouse != null && pubhouse != 0)
            {
                books = books.Where(b => b.PubhouseId == pubhouse);
            }

            var authors = _context.Authors
                .Join(_context.AuthorBookMaps,
                e => e.Id, e => e.Author.Id,
                (author, authorBook) => new { Author = author, Book = authorBook.Book });

            pubyearMin ??= 0;
            pubyearMax ??= int.MaxValue;
            books = books.Where(b => b.Pubyear >= pubyearMin && b.Pubyear <= pubyearMax);

            // полнотекстовый поиск

            if (!string.IsNullOrEmpty(searchText))
            {
                books = books.FullTextSearchQuery(searchText);
            }

            // сортировка
            switch (sortOrder)
            {
                case BooksSortState.PubyearDesc:
                    books = books.OrderByDescending(b => b.Pubyear);
                    break;
                default:
                    books = books.OrderBy(b => b.Pubyear);
                    break;
            }

            var foundCount = books.Count();

            //  пагинация
            var count = await books.CountAsync();  //  общее к-во элементов
            var items = await books.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            BooksListViewModel viewModel = new BooksListViewModel
            {
                PageViewModel = pageViewModel,
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(_context.Pubhouses.ToList(), pubhouse, searchText, pubyearMin, pubyearMax),
                Books = items,
                Count = foundCount
            };
            return View(viewModel);
        }
    }
}