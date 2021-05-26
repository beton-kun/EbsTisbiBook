using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EbsTisbiBook.WebAppMVC.Models.Identity
{
    public class User : IdentityUser
    {
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Display(Name = "Отчество")]
        public string Middlename { get; set; }

        [Display(Name = "Возраст")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "В черном списке")]
        public bool isBlocked { get; set; }
    }
}
