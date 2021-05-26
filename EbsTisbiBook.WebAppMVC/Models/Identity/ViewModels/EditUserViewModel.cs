using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbsTisbiBook.WebAppMVC.Models.Identity.ViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
