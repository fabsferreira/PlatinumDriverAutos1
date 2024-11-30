using System.ComponentModel.DataAnnotations;

namespace PlatinumDriverAutos.Models
{
    public class Funcionario
    {
        public int Id { get; set; }

        [Required] // Garante que o campo Nome não será nulo
        [StringLength(100)] // Limita o comprimento do nome
        public string Nome { get; set; }

        [Required] // Garante que o campo Email não será nulo
        [EmailAddress] // Valida se o valor é um endereço de e-mail válido
        [StringLength(100)] // Limita o comprimento do e-mail
        public string Email { get; set; }

        [Required] // Garante que o campo Telefone não será nulo
        [StringLength(20)] // Limita o comprimento do telefone
        public string Telefone { get; set; }

        [Required] // Garante que o campo Cargo não será nulo
        [StringLength(50)] // Limita o comprimento do cargo
        public string Cargo { get; set; }
    }
}
