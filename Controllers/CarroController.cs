using Microsoft.AspNetCore.Mvc;

namespace PlatinumDriverAutos.Controllers
{
    public class CarroController : Controller
    {
        public IActionResult Carros() => View();
        public IActionResult Compradocarro(string carro)
            {
                // Simulando uma base de dados com informações dos carros
                var carros = new Dictionary<string, dynamic>
            {
                { "1", new { Nome = "Chevrolet Onix LT MT", Ano = 2025, Preco = "R$ 97.990", Cor = "Preto" } },
                { "2", new { Nome = "Nissan Kicks", Ano = 2024, Preco = "R$ 106.490", Cor = "Branco" } },
                { "3", new { Nome = "Hyundai HB20 2025 Comfort", Ano = 2025, Preco = "R$ 110.490", Cor = "Cinza" } },
                { "4", new { Nome = "Hyundai Creta 2025 Limited", Ano = 2025, Preco = "R$ 156.490", Cor = "Cinza" } },
                { "5", new { Nome = "Volkswagen Nivus", Ano = 2024, Preco = "R$ 119.990", Cor = "Azul" } }
            };

                if (carros.TryGetValue(carro, out var carroSelecionado))
                {
                    ViewData["CarroSelecionado"] = carroSelecionado;
                    ViewData["CarroId"] = carro;
                }
                else
                {
                    ViewData["CarroSelecionado"] = null;
                }

                return View();
            }

            // Método para processar o envio da compra
            [HttpPost]
            public IActionResult ProcessarCompra(string nome, string email, string telefone, string endereco, string carroId)
            {
                // Lógica para processar a compra, como salvar em banco de dados, enviar confirmação por e-mail, etc.
                // Simulação de processamento
                var compra = new
                {
                    Nome = nome,
                    Email = email,
                    Telefone = telefone,
                    Endereco = endereco,
                    CarroId = carroId
                };

                // Após o processamento, retorna um status ou confirmação
                return Json(new { success = true, message = "Compra realizada com sucesso!" });
            }

        // Página de confirmação de compra
        public IActionResult Confirmacao() => View();
    }
    }
