using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EbsTisbiBook.WebAppMVC.Models.Library
{
    public partial class Author
    {
        public Author()
        {
            AuthorBookMaps = new HashSet<AuthorBookMap>();
        }

        public int Id { get; set; }

        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Display(Name = "Отчество")]
        public string Middlename { get; set; }

        public virtual ICollection<AuthorBookMap> AuthorBookMaps { get; set; }
    }
}
