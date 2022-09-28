﻿using MovieApp.DataAccess.Repository;
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
        private readonly IMovieRepository _movieRepository;
        private readonly IUserRepository _userRepository;
        private readonly IGenerateToken _token;
        private readonly IHasher _hasher;
        public UserService(IUserRepository userRepository, IGenerateToken token, IMovieRepository movieRepository, IHasher hasher)
        {
            _userRepository = userRepository;
            _movieRepository = movieRepository;
            _token = token;
            _hasher = hasher;
        }

        public void AddNewMovie(int id, string username)
        {

            User user = _userRepository.GetUser(username);
            Movie movieModel = _movieRepository.GetByID(id);
            if (movieModel != null)
            {
                FavoriteMovies movie = new()
                {
                    Movie = movieModel
                };
                user.MoviesList.Add(movie);
                _userRepository.Update(user);
            }
            else
            {
                throw new MovieException("No movie found");
            }
        }

        public string Authenticate(LoginUserDto userDto)
        {
            User user = _userRepository.GetUser(userDto.Username);
            var password = _hasher.Hash(userDto.Password);
            if (user != null && password == user.Password)
            {
                return _token.Token(user.Id, user.Username);
            }
            else
            {
                throw new UserException("No user found");
            }
        }

        public void ForgotPassword(UpdateUserDto user)
        {
            if (user.NewPassword == user.ConfirmPassword)
            {
                User userModel = _userRepository.GetUser(user.Username);
                if (userModel != null)
                {
                    User newUser = new()
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

        public List<UserDto> GetUsers()
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

        public void RegisterUser(RegisterUserDto user)
        {
            if (GetUsers().Any(x => x.Username == user.Username))
            {
                throw new UserException("Username taken");
            }
            else
            {
                User userDto = new User()
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
            User user = _userRepository.GetUser(username);
            FavoriteMovies movieModel = _movieRepository.GetFavMovie(id);
            if (movieModel != null)
            {
                user.MoviesList.Remove(movieModel);
                _userRepository.Update(user);
            }
        }
    }
}
