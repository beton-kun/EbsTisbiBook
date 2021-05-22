using Microsoft.EntityFrameworkCore.Internal;

namespace EbsTisbiBook.WebAppMVC.Models.Library.ViewModels
{
    public class SortViewModel
    {
        public BooksSortState PubyearSort { get; private set; }
        public BooksSortState Current { get; private set; }
        public SortViewModel(BooksSortState sortOrder)
        {
            PubyearSort = sortOrder == BooksSortState.PubyearAsc ? BooksSortState.PubyearDesc : BooksSortState.PubyearAsc;
            Current = sortOrder;
        }
    }
}