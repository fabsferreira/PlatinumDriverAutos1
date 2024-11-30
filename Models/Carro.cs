using System.ComponentModel.DataAnnotations;

namespace PlatinumDriverAutos.Models
{
    public class Carro
    {
        public int Id { get; set; }

        [Required] // Garante que o campo Modelo não será nulo
        [StringLength(100)] // Define um limite para o tamanho da string
        public string Modelo { get; set; }

        [Required] // Garante que o campo Marca não será nulo
        [StringLength(100)] // Define um limite para o tamanho da string
        public string Marca { get; set; }

        [Range(1900, 2100)] // Limita o intervalo de anos
        public int Ano { get; set; }

        [Required] // Garante que o campo Cor não será nulo
        [StringLength(50)] // Define um limite para o tamanho da string
        public string Cor { get; set; }

        [Required] // Garante que o campo Preço não será nulo
        [Range(0, 1000000)] // Define o intervalo aceitável para o preço
        [DataType(DataType.Currency)] // Indica que o dado é do tipo moeda
        public decimal Preco { get; set; }
    }
}
