using MovieApp.DataAccess.Repository;
using MovieApp.DomainModel;
using MovieApp.DomainModels;
using MovieApp.Exceptions;
using MovieApp.HelperMethods;
using MovieApp.InterfaceModels.InterfaceModelUsers;
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
        private readonly IRepository<MovieDto> _movieRepository;
        private readonly IHasher _hasher;
        public UserService(IRepository<UserDto> userRepository, IUserRepository userFilterRepository, IGenerateToken token, IMovieRepository movieFilterRepository, IRepository<MovieDto> movieRepository, IHasher hasher)
        {
            _userRepository = userRepository;
            _userFilterRepository = userFilterRepository;
            _movieFilterRepository = movieFilterRepository;
            _token = token;
            _movieRepository = movieRepository;
            _hasher = hasher;
        }

        public void AddNewMovie(int id, string username)
        {

                UserDto user = _userFilterRepository.GetUser(username);
                MovieDto movieModel = _movieRepository.GetByID(id);
                if (movieModel != null)
                {
                    FavoriteMoviesDto movie = new()
                    {
                        MovieDto = movieModel
                    };
                    user.MoviesList.Add(movie);
                    _userRepository.Update(user);
                }
                else
                {
                    throw new MovieException("No movie found");
                }
        }

        public string Authenticate(LoginUser user)
        {
            UserDto userDto = _userFilterRepository.GetUser(user.Username);
            var password = _hasher.Hash(user.Password);
            if (userDto != null && password == userDto.Password)
            {
                return _token.Token(userDto.Id, userDto.Username);
            }
            else
            {
                throw new UserException("No user found");
            }
        }

        public void ForgotPassword(UpdateUser user)
        {
            if (user.NewPassword == user.ConfirmPassword)
            {
                UserDto userModel = _userFilterRepository.GetUser(user.Username);
                if (userModel != null)
                {
                    UserDto newUser = new()
                    {
                        Id = userModel.Id,
                        FirstName = userModel.FirstName,
                        LastName = userModel.LastName,
                        FavoriteGenre = userModel.FavoriteGenre,
                        Username = userModel.Username,
                        Password = _hasher.Hash(user.NewPassword),
                        MoviesList = userModel.MoviesList
                    };
                    _userRepository.Update(newUser);
                }
                else
                {
                    throw new UserException("User with that username doesn't exist");
                }

            }
            else
            {
                throw new UserException("Passwords don't match");
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
                    Password = _hasher.Hash(user.Password),
                    FavoriteGenre = user.FavoriteGenre
                };
                _userRepository.Add(userDto);
            }

        }

        public void RemoveMovie(int id, string username)
        {
                UserDto user = _userFilterRepository.GetUser(username);
                FavoriteMoviesDto movieModel = _movieFilterRepository.GetFavMovie(id);
                if (movieModel != null)
                {
                    user.MoviesList.Remove(movieModel);
                    _userRepository.Update(user);
                }
        }
    }
}
