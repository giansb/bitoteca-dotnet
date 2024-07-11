using BitotecaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BitotecaApi.Data
{
    public class LivroContext : DbContext
    {
        public LivroContext(DbContextOptions<LivroContext> opts) : base(opts)
        {

        }

        public DbSet<Livro> Livro { get; set; }
    }
}
