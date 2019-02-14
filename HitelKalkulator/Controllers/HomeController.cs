using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HitelKalkulator.Models;

namespace HitelKalkulator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HitelSzamol
            (int osszeg, int futamido, int kamat)
        {
            double fixtorleszto = osszeg / futamido;
            double tartozas = osszeg;

            double ossztartozas = 0;

            double[,] matrix = new double[futamido, 5];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, 0] = i + 1;
                matrix[i, 1] = tartozas;
                tartozas -= fixtorleszto;

                matrix[i, 2] = tartozas * 
                    ((double)kamat / 100);

                matrix[i, 3] = fixtorleszto;

                matrix[i, 4] = matrix[i, 3] + matrix[i, 2];

                ossztartozas += matrix[i, 4];
            }

            return View(new HitelViewModel()
            {
                Osszar = ossztartozas,
                Adatok = matrix
            });


        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
