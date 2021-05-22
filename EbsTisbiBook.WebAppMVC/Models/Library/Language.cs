using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EbsTisbiBook.WebAppMVC.Models.Library
{
    [Display(Name = "Язык")]
    public partial class Language
    {
        public Language()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }

        [Display(Name = "Наименование")]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
