using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Helpers;
using MovieApp.InterfaceModels;
using MovieApp.Services.Abstraction;

namespace MovieApp_API.Controllers
{
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
            return Ok(_movieService.GetMovies());
        }
        [HttpGet("GetMovieById")]
        public IActionResult GetById([FromQuery] int id)
        {
            try
            {
                return Ok(_movieService.GetById(id));
            }
            catch (MovieException ex)
            {
                return BadRequest(ex.Message);
            }
         
        }
        [HttpGet("GetMoviesByGenre/{genre}")]
        public IActionResult GetByGenre([FromRoute] string genre)
        {
            try
            {
                return Ok(_movieService.GetByGenre(genre));
            }
            catch (MovieException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddNewMovie")]
        public IActionResult AddMovie([FromBody] AddMovie movie)
        {
            try
            {
                _movieService.AddMovie(movie);
                return Ok("Movie added");
            }
            catch (MovieException ex)
            {
                return BadRequest(ex.Message);
            }
            
            
        }
    }
}
