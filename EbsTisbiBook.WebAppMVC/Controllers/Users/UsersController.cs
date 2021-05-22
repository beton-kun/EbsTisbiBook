using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EbsTisbiBook.WebAppMVC.Controllers.Users
{
    public class UsersController : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }
    }
}