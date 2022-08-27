using MovieApp.DataAccess.Repository;
using MovieApp.DomainModel;
using MovieApp.DomainModels;
using MovieApp.InterfaceModels;
using MovieApp.Services.Abstraction;
using MovieApp.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserDto> _userRepository;
        private readonly IRepository<MovieDto> _movieRepository;
        public UserService(IRepository<UserDto> userRepository, IRepository<MovieDto> movieRepository)
        {
            _userRepository = userRepository;
            _movieRepository = movieRepository;
        }

        public void AddNewMovie(AddFavoriteMovie list)
        {
          UserDto user = _userRepository.GetByID(list.UserId);
            FavoriteMoviesDto movie = new()
            {
                MovieDto = _movieRepository.GetByID(list.MovieId),
                MovieDtoId = list.MovieId
            };
            user.MoviesList.Add(movie);
            _userRepository.Update(user);
        }

        public void Authenticate(LoginUser user)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            return _userRepository.GetAll().Select(x => x.ToReqModel()).SingleOrDefault(x => x.Id == id);
        }

        public List<User> GetUsers()
        {
           return _userRepository.GetAll().Select(x => x.ToReqModel()).ToList();
        }

        public void RegisterUser(RegisterUser user)
        {
          UserDto userDto =  new UserDto()
                             {
                                FirstName = user.FirstName,
                                LastName = user.LastName,
                                Username = user.Username,
                                Password = user.Password, //need to hash
                                FavoriteGenre = user.FavoriteGenre
                             };
            _userRepository.Add(userDto);
        }

    }
}
