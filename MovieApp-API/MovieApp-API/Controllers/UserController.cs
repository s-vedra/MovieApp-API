using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.InterfaceModels.InterfaceModelUsers;
using MovieApp.Services.Abstraction;
using Serilog;
using System.Security.Claims;

namespace MovieApp_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult RegisterUser([FromBody] RegisterUserDto user)
        {
            try
            {
                Log.Information($"{user.FirstName} has been registered");
                _userService.RegisterUser(user);
                return Ok("User added");
            }
            catch (Exception ex)
            {
                Log.Error($"User entered {user.Username} which already exists");
                return BadRequest(ex.Message);
            }

        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Authenticate([FromBody] LoginUserDto user)
        {
            try
            {
                Log.Information($"{user.Username} has logged in");
                return Ok(_userService.Authenticate(user));
            }
            catch (Exception ex)
            {
                Log.Error($"User with the username {user.Username} wasn't found");
                return BadRequest(ex.Message);
            }

        }
        [AllowAnonymous]
        [HttpPut("ForgotPassword")]
        public IActionResult ForgotPassword([FromBody] UpdateUserDto user)
        {
            try
            {
                Log.Information($"{user.Username} changed his password");
                _userService.ForgotPassword(user);
                return Ok("Password changed");
            }
            catch (Exception ex)
            {
                Log.Error($"Something went wrong while changing password");
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetUsers")]
        public IActionResult GetAllUsers()
        {
            try
            {
                Log.Information($"Returned all users");
                return Ok(_userService.GetUsers());
            }
            catch (Exception ex)
            {
                Log.Error($"No users in the DB");
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("AddMovie/{id}")]
        public IActionResult AddFavoriteMovie(int id)
        {
            try
            {
                var user = User.FindFirst(ClaimTypes.Name).Value;
                Log.Information($"{user} has added a new movie in his list");
                _userService.AddNewMovie(id, user);
                return Ok("Movie added");
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("DeleteFavMovie/{id}")]
        public IActionResult RemoveMovie([FromRoute] int id)
        {
            try
            {
                var user = User.FindFirst(ClaimTypes.Name).Value;
                Log.Information($"{user} has removed a movie from his list");
                _userService.RemoveMovie(id, user);
                return Ok("Movie removed");
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
