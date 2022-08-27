using MovieApp.DataAccess.Repository;
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
        public UserService(IRepository<UserDto> userRepository)
        {
            _userRepository = userRepository;
        }
        public void Authenticate(LoginUser user)
        {
            throw new NotImplementedException();
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
