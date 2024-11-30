using Microsoft.EntityFrameworkCore;
using PlatinumDriverAutos.Models; // Certifique-se de que seu modelo Funcionario e Carro estão na pasta Models

namespace PlatinumDriverAutos.Data
{
    public class PlatinumDriveContext : DbContext
    {
        public PlatinumDriveContext(DbContextOptions<PlatinumDriveContext> options) : base(options) { }

        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Carro> Carro { get; set; }
    }
   }

