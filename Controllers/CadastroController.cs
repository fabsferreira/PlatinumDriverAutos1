using Microsoft.AspNetCore.Mvc;
using PlatinumDriverAutos.Data; // Referência ao DbContext
using PlatinumDriverAutos.Models;
using System.Linq;

namespace PlatinumDriverAutos.Controllers
{
    [Route("cadastro")]
    public class CadastroController : Controller
    {
        private readonly PlatinumDriveContext _context;

        public CadastroController(PlatinumDriveContext context)
        {
            _context = context;
        }

        // Cadastro de Funcionário
        [Route("CadFuncionario")]
        public IActionResult CadFuncionario() => View();

        [HttpPost]
        [Route("InserirFuncionario")]
        public IActionResult InserirFuncionario([FromBody] Funcionario funcionario)
        {
            if (funcionario == null)
                return BadRequest("Dados inválidos.");

            _context.Funcionario.Add(funcionario);
            _context.SaveChanges();
            return Json(new { success = true, message = "Funcionário cadastrado com sucesso!" });
        }

        [Route("ListaFuncionarios")]
        public IActionResult ListaFuncionarios()
        {
            var funcionarios = _context.Funcionario.ToList();
            return View(funcionarios);
        }

        [Route("EditarFuncionario/{id}")]
        public IActionResult EditarFuncionario(int id)
        {
            var funcionario = _context.Funcionario.Find(id);
            if (funcionario == null)
                return NotFound();

            return View(funcionario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("SalvarEdicaoFuncionario")]
        public IActionResult SalvarEdicaoFuncionario([FromForm] Funcionario funcionarioAtualizado)
        {
            var funcionario = _context.Funcionario.Find(funcionarioAtualizado.Id);
            if (funcionario == null)
                return NotFound();

            funcionario.Nome = funcionarioAtualizado.Nome;
            funcionario.Email = funcionarioAtualizado.Email;
            funcionario.Telefone = funcionarioAtualizado.Telefone;
            funcionario.Cargo = funcionarioAtualizado.Cargo;

            _context.SaveChanges();
            return RedirectToAction("ListaFuncionarios");
        }

        [Route("ExcluirFuncionario/{id}")]
        public IActionResult ExcluirFuncionario(int id)
        {
            var funcionario = _context.Funcionario.Find(id);
            if (funcionario == null)
                return NotFound();

            _context.Funcionario.Remove(funcionario);
            _context.SaveChanges();
            return RedirectToAction("ListaFuncionarios");
        }

        // Cadastro de Carro
        [Route("CadCarro")]
        public IActionResult CadCarro() => View();

        [HttpPost]
        [Route("InserirCarro")]
        public IActionResult InserirCarro([FromBody] Carro carro)
        {
            if (carro == null)
                return BadRequest("Dados inválidos.");

            _context.Carro.Add(carro);
            _context.SaveChanges();
            return Json(new { success = true, message = "Carro cadastrado com sucesso!" });
        }

        [Route("ListaCarros")]
        public IActionResult ListaCarros()
        {
            var carros = _context.Carro.ToList();
            return View(carros);
        }

        [Route("EditarCarro/{id}")]
        public IActionResult EditarCarro(int id)
        {
            var carro = _context.Carro.Find(id);
            if (carro == null)
                return NotFound();

            return View(carro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("SalvarEdicaoCarro")]
        public IActionResult SalvarEdicaoCarro([FromForm] Carro carroAtualizado)
        {
            var carro = _context.Carro.Find(carroAtualizado.Id);
            if (carro == null)
                return NotFound();

            carro.Modelo = carroAtualizado.Modelo;
            carro.Marca = carroAtualizado.Marca;
            carro.Ano = carroAtualizado.Ano;
            carro.Cor = carroAtualizado.Cor;
            carro.Preco = carroAtualizado.Preco;

            _context.SaveChanges();
            return RedirectToAction("ListaCarros");
        }

        [Route("ExcluirCarro/{id}")]
        public IActionResult ExcluirCarro(int id)
        {
            var carro = _context.Carro.Find(id);
            if (carro == null)
                return NotFound();

            _context.Carro.Remove(carro);
            _context.SaveChanges();
            return RedirectToAction("ListaCarros");
        }
    }
}
