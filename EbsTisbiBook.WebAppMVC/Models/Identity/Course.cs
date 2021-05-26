using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace EbsTisbiBook.WebAppMVC.Models.Identity
{
    [Display(Name = "Курс")]
    public class Course
    {
        public int Id { get; set; }

        [Display(Name = "Наименование")]
        public string Name { get; set; }
    }
}
