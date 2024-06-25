using Teste.Models;
using Microsoft.EntityFrameworkCore;

namespace Teste.Data
{
    public class DbContextTeste: DbContext
    {
        public DbContextTeste(DbContextOptions<DbContextTeste> options) : base(options)
        {
        }

        public DbSet<EventosModels> Eventos { get; set; }
        public DbSet<LocaisModels> Locais { get; set; }
    }
}
