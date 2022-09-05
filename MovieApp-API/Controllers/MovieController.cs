using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.InterfaceModels;
using MovieApp.Services.Abstraction;
using Serilog;

namespace MovieApp_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("GetMovies")]
        public IActionResult GetMovies()
        {
            try
            {
                Log.Information("Movies were returned");
                return Ok(_movieService.GetMovies());
            }
            catch (Exception ex)
            {
                Log.Error("No movies found in db");
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("GetMovieById")]
        public IActionResult GetById([FromQuery] int id)
        {
            try
            {
                Log.Information($"Movie with the {id} was returned");
                return Ok(_movieService.GetById(id));
            }
            catch (Exception ex)
            {
                Log.Error($"No movie found with the id {id}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetMoviesByGenre/{genre}")]
        public IActionResult GetByGenre([FromRoute] string genre)
        {
            try
            {
                Log.Information($"Movies with the genre {genre} were returned");
                return Ok(_movieService.GetByGenre(genre));
            }
            catch (Exception ex)
            {
                Log.Error($"No movies with the genre {genre} were found");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddNewMovie")]
        public IActionResult AddMovie([FromBody] AddMovie movie)
        {
            try
            {
                Log.Information($"New movie was added in the db with the title {movie.Title}");
                _movieService.AddMovie(movie);
                return Ok("Movie added");
            }
            catch (Exception ex)
            {
                Log.Error($"Something went wrong with the movie {movie.Title} while adding it to the db");
                return BadRequest(ex.Message);
            }
        }
    }
}
