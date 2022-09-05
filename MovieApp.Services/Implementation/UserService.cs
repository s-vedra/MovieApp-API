using MovieApp.DataAccess.Repository;
using MovieApp.DomainModels;
using MovieApp.Exceptions;
using MovieApp.HelperMethods;
using MovieApp.InterfaceModels;
using MovieApp.Services.Abstraction;
using MovieApp.Services.Mappers;

namespace MovieApp.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserDto> _userRepository;
        private readonly IMovieRepository _movieFilterRepository;
        private readonly IUserRepository _userFilterRepository;
        private readonly IGenerateToken _token;
        public UserService(IRepository<UserDto> userRepository, IUserRepository userFilterRepository, IGenerateToken token, IMovieRepository movieFilterRepository)
        {
            _userRepository = userRepository;
            _userFilterRepository = userFilterRepository;
            _movieFilterRepository = movieFilterRepository;
            _token = token;
        }

        public void AddNewMovie(string movieName, string username)
        {
            if (!string.IsNullOrEmpty(movieName))
            {
                UserDto user = _userFilterRepository.GetUser(username);
                FavoriteMoviesDto movie = new()
                {
                    MovieDto = _movieFilterRepository.GetByName(movieName)
                };
                user.MoviesList.Add(movie);
                _userRepository.Update(user);
            }
            else
            {
                throw new MovieException("Movie is required");
            }

        }

        public string Authenticate(LoginUser user)
        {
            UserDto userDto = _userFilterRepository.GetUser(user.Username);
            var password = user.Password.Hash();
            if (userDto != null && password == userDto.Password)
            {
                return _token.Token(userDto.Id, userDto.Username);
            }
            else
            {
                throw new UserException("No user found");
            }
        }

        public List<User> GetUsers()
        {
            var users = _userRepository.GetAll().Select(x => x.Value.ToReqModel()).ToList();
            if (users.Count != 0)
            {
                return users;
            }
            else
            {
                throw new UserException("No users found");
            }
        }

        public void RegisterUser(RegisterUser user)
        {
            if (GetUsers().Any(x => x.Username == user.Username))
            {
                throw new UserException("Username taken");
            }
            else
            {
                UserDto userDto = new UserDto()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Username = user.Username,
                    Password = user.Password.Hash(),
                    FavoriteGenre = user.FavoriteGenre
                };
                _userRepository.Add(userDto);
            }

        }

    }
}
