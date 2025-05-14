
namespace Movies.Application.UseCases.Movies
{
    public interface IMovieUseCase
    {
        List<Core.Entities.Movie> GetMovies(string title, int? year, List<string> genre);
    }
}
