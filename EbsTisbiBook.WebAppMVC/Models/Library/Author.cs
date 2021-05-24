using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EbsTisbiBook.WebAppMVC.Models.Library
{
    public partial class Author
    {
        public int Id { get; set; }

        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Display(Name = "Отчество")]
        public string Middlename { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
