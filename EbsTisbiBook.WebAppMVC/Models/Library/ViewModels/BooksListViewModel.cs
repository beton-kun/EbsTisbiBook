using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EbsTisbiBook.WebAppMVC.Models.Library;
namespace EbsTisbiBook.WebAppMVC.Models.Library.ViewModels
{
    public class BooksListViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public int Count { get; set; }
        public SortViewModel SortViewModel
        {
            get; set;
        }
    }
}
