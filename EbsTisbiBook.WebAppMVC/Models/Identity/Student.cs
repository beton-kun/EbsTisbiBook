using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbsTisbiBook.WebAppMVC.Models.Identity
{
    public class Student : User
    {
        public Course Course { get; set; }
    }
}
