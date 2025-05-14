using Movies.Core.Entities;

namespace Movies.Core.Repository
{
    public interface IMovieRepository
    {
        List<Movie> GetMovies(string title, int? year, List<string> genre);
    }
}
