using BitotecaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BitotecaApi.Data
{
    public class IdiomaContext : DbContext
    {
        public IdiomaContext(DbContextOptions<IdiomaContext> opts): base(opts)  {
            
        }

        public DbSet<Idioma> Idioma { get; set; }
    }
}
