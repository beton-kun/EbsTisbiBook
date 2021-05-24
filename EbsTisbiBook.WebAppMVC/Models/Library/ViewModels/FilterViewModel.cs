using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EbsTisbiBook.WebAppMVC.Models.Library.ViewModels
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Pubhouse> pubhouses, int? pubhouse, List<Author> authors, int? author, string searchText, int? pubyearMin, int? pubyearMax)
        {
            pubhouses.Insert(0, new Pubhouse { Name = "Все", Id = 0 });
            Pubhouses = new SelectList(pubhouses, "Id", "Name", pubhouse);
            SelectedPubhouse = pubhouse;

            authors.Insert(0, new Author { Surname = "Все", Id = 0 });
            Authors = new SelectList(authors, "Id", "Surname", author);
            SelectedAuthor = author;

            SearchText = searchText;
            SelectedPubyearMin = pubyearMin == 0 ? null : pubyearMin;
            SelectedPubyearMax = pubyearMax == int.MaxValue ? null : pubyearMax;
        }
        public SelectList Pubhouses { get; private set; }
        public int? SelectedPubhouse { get; private set; }
        public SelectList Authors { get; private set; }
        public int? SelectedAuthor { get; private set; }
        public int? SelectedPubyearMin { get; private set; }
        public int? SelectedPubyearMax { get; private set; }
        public string SearchText { get; set; }
    }
}