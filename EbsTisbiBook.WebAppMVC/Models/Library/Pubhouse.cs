using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EbsTisbiBook.WebAppMVC.Models.Library
{
    [Display(Name = "Издательство")]
    public partial class Pubhouse
    {
        public Pubhouse()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
