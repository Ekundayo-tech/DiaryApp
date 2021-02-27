using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RpMovies.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpMovies.Model
{
    public class SeedData
    {
        public static void Initializer(IServiceProvider serviceProvider)
        {
            using(var context = new RpMoviesContext(
                serviceProvider.GetRequiredService<DbContextOptions<RpMoviesContext>>()))
            {
                if(context.Movie.Any())
                {
                    return;
                }
                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Joe",
                        ReleasedDate = DateTime.Parse("1996-6-09"),
                        Price = 79M
                    },
                    new Movie
                    {
                        Title = "When Harry Met Joe",
                        ReleasedDate = DateTime.Parse("1996-6-09"),
                        Price = 79M
                    },
                    new Movie
                    {
                        Title = "When Harry Met Joe",
                        ReleasedDate = DateTime.Parse("1996-6-09"),
                        Price = 79M
                    },
                    new Movie
                    {
                        Title = "When Harry Met Joe",
                        ReleasedDate = DateTime.Parse("1996-6-09"),
                        Price = 79M
                    },
                    new Movie
                    {
                        Title = "When Harry Met Joe",
                        ReleasedDate = DateTime.Parse("1996-6-09"),
                        Price = 79M
                    },
                    new Movie
                    {
                        Title = "When Harry Met Joe",
                        ReleasedDate = DateTime.Parse("1996-6-09"),
                        Price = 79M
                    },
                    new Movie
                    {
                        Title = "When Harry Met Joe",
                        ReleasedDate = DateTime.Parse("1996-6-09"),
                        Price = 79M
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
