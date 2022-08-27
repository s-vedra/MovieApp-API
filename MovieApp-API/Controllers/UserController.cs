using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.InterfaceModels;
using MovieApp.Services.Abstraction;

namespace MovieApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Register")]
        public IActionResult RegisterUser([FromBody] RegisterUser user)
        {
            _userService.RegisterUser(user);
            return Ok("User added");
        }
        [HttpGet("GetUsers")]
        public IActionResult GetAllUsers()
        {
            //implement exceptions
            return Ok(_userService.GetUsers());
        }
        [HttpPost("AddMovie")]
        public IActionResult AddFavoriteMovie([FromBody] AddFavoriteMovie list)
        {
            _userService.AddNewMovie(list);
            return Ok();
        }
    }
}
