using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Melodix;

    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
public DbSet<Melodix.Cancion> Canciones { get; set; } = default!;

public DbSet<Melodix.Anuncio> Anuncios { get; set; } = default!;

public DbSet<Melodix.Reproduccion> Reproducciones { get; set; } = default!;

public DbSet<Melodix.Like> Likes { get; set; } = default!;

public DbSet<Melodix.ListaReproduccion> ListaReproducciones { get; set; } = default!;

public DbSet<Melodix.ListaCancion> ListaCanciones { get; set; } = default!;
    }
