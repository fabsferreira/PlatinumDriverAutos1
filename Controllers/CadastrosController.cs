using Microsoft.AspNetCore.Mvc;
using PlatinumDriverAutos.Models;
using System.Diagnostics;

namespace PlatinumDriverAutos.Controllers
{
    public class CadastrosController : Controller
    {
        public IActionResult CadFuncionario() => View();
        public IActionResult CadCarro() => View();
        public IActionResult ListarFuncionarios() => View();
    }
}

