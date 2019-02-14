using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP01_hello.Controllers
{
    public class CarController : Controller
    {
        public string List()
        {
            return "bmw, audi, opel";
        }
    }
}
