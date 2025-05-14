using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Applications.UseCases.Movies;
using Movies.Infraestructure;
using System;

namespace MoviesTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieUseCase _movieUseCase;

        public MovieController(IMovieUseCase movieUseCase)
        {
            _movieUseCase = movieUseCase;
        }

        [HttpGet]
        public IActionResult GetMovies([FromQuery] string? title, [FromQuery] int? year, [FromQuery] List<string>? genre)
        {
            var movies = _movieUseCase.GetMovies(title, year, genre);

            return Ok(movies);
        }
    }
}
