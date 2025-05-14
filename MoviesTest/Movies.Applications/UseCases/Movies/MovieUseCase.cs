using Movies.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Applications.UseCases.Movies
{
    public class MovieUseCase : IMovieUseCase
    {
        private readonly IMovieRepository _repository;

        public MovieUseCase(IMovieRepository repository)
        {
            _repository = repository;
        }
        public List<Core.Entities.Movie> GetMovies(string title, int? year, List<string> genre)
        {
            return _repository.GetMovies(title, year, genre);
        }
    }
}
