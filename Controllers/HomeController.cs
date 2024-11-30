using Microsoft.AspNetCore.Mvc;
using PlatinumDriverAutos.Models;
using System.Diagnostics;

namespace PlatinumDriverAutos.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult Carros() => View();
        public IActionResult Sobre() => View();
    }
}

