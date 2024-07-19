﻿using BitotecaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BitotecaApi.Data;

public class EditoraContext : DbContext
{
    public EditoraContext(DbContextOptions<AutorContext> opts) : base(opts)
    {

    }

    public DbSet<Editora> Editora { get; set; }
}
