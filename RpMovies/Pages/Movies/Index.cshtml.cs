using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RpMovies.Data;
using RpMovies.Model;

namespace RpMovies.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RpMovies.Data.RpMoviesContext _context;

        public IndexModel(RpMovies.Data.RpMoviesContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }
        [BindProperty(SupportsGet =true)]
        public string Searching{ get; set; }
       
        public async Task OnGetAsync()
        {
            var movies = from m in _context.Movie
                         select m;
            if (!string.IsNullOrEmpty(Searching))
            {
                movies = movies.Where(s => s.Title.Contains(Searching));
            }
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
