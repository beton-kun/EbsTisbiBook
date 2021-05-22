using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EbsTisbiBook.WebAppMVC.Models.Library
{
    [Display(Name = "УГНП")]
    public partial class Ugnp
    {
        public Ugnp()
        {
            Fgos = new HashSet<Fgos>();
        }

        public int Id { get; set; }

        [Display(Name = "Наименование")]
        public string Name { get; set; }

        public virtual ICollection<Fgos> Fgos { get; set; }
    }
}
