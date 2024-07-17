using BitotecaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BitotecaApi.Data;

public class GeneroContext :DbContext
{
    public GeneroContext(DbContextOptions<GeneroContext> opts) : base(opts)
    {

    }

    public DbSet<Genero> Genero { get; set; }
}
