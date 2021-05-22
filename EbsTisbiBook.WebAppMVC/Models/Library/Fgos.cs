﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EbsTisbiBook.WebAppMVC.Models.Library
{
    [Display(Name = "ФГОС")]
    public partial class Fgos
    {
        public Fgos()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }

        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Display(Name = "УГНП")]
        public int? UgnpId { get; set; }

        public virtual Ugnp Ugnp { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
