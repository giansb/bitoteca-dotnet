using BitotecaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BitotecaApi.Data
{
    public class AutorContext : DbContext
    {
        public AutorContext(DbContextOptions<AutorContext> opts) : base(opts)
        {
                
        }

        public DbSet<Autor> Autor {  get; set; } 
    }
}
