using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP01_hello.Controllers
{
    public class HomeController : Controller
    {
        static Random r = new Random();
        public string Index()
        {
            return "Ez a főoldal!";
        }

        public IActionResult Hello()
        {
            return View(); 
            //visszaküldi a Views/Home/Hello.cshtml válaszát
        }

        public IActionResult Sorsolo()
        {
            string[] nevek = {
                "Csink László",
                "Vámossy Zoltán",
                "Sergyán Szabolcs",
                "Galántai Aurél"
            };

            return View("Sorsolo", 
                nevek[r.Next(0, nevek.Length)]);
        }
    }
}
