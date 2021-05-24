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

        public async Task<IActionResult> List(int? pubhouse, int? author, int? pubyearMin, int? pubyearMax, string searchText, int page = 1,
            BooksSortState sortOrder = BooksSortState.PubyearAsc)
        {
            var pageSize = 4;   // количество элементов на странице

            //  фильтрация
            IQueryable<Book> books = _context.Books
                .Include(b => b.Pubhouse)
                .Include(a => a.Authors);

            if (pubhouse != null && pubhouse != 0)
            {
                books = books.Where(b => b.PubhouseId == pubhouse);
            }

            if (author != null && author != 0)
            {
                books = books.Where(b => b.Authors.Contains(
                    _context.Authors.FirstOrDefault(a => a.Id == author)));
            }

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
                FilterViewModel = new FilterViewModel(_context.Pubhouses.ToList(), pubhouse, _context.Authors.ToList(), author, searchText, pubyearMin, pubyearMax),
                Books = items,
                Count = foundCount
            };
            return View(viewModel);
        }

        public IActionResult Book(int id)
        {
            var model = _context.Books
                .Include(b => b.Pubhouse)
                .Include(a => a.Authors)
                .FirstOrDefault(b => b.Id == id);
            return View(model);
        }
    }
}