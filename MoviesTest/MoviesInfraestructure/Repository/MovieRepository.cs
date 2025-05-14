using Movies.Core.Entities;
using Movies.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infraestructure.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApiDbContext _context;

        public MovieRepository(ApiDbContext context)
        {
            _context = context;
        }
        public List<Movie> GetMovies(string title, int? year, List<string> genre)
        {
            if (string.IsNullOrEmpty(title) && year == null && (genre == null || !genre.Any()))
            {
                throw new ArgumentNullException("You must provide at least one filter criterion: title, year, or genre.");
            }

            var query = _context.Movie.AsQueryable();

            if (!string.IsNullOrEmpty(title))
                query = query.Where(m => m.Title.Contains(title));

            if (year.HasValue)
                query = query.Where(m => m.Year == year.Value);

            var movies = query.ToList();

            return movies;
            
        }
    }
}
