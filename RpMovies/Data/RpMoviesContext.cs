using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RpMovies.Model;

namespace RpMovies.Data
{
    public class RpMoviesContext : DbContext
    {
        public RpMoviesContext (DbContextOptions<RpMoviesContext> options)
            : base(options)
        {
        }

        public DbSet<RpMovies.Model.Movie> Movie { get; set; }
    }
}
