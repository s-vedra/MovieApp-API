using MovieApp.DomainModel;
using MovieApp.DomainModels;
using MovieApp.InterfaceModels.InterfaceModelUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services.Mappers
{
    public static class UserMapper
    {
        public static User ToReqModel(this UserDto source)
        {
            return new User()
            {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                FavoriteGenre = source.FavoriteGenre,
                Password = source.Password,
                Username = source.Username,
                MoviesList = source.MoviesList.Select(x => x.ToReqModel()).ToList()
            };
        }
        public static UserDto ToReqModel(this User source)
        {
            return new UserDto()
            {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                FavoriteGenre = source.FavoriteGenre,
                Password = source.Password,
                Username = source.Username,
                MoviesList = source.MoviesList.Select(x => x.ToReqModel()).ToList()
            };
        }
    }
}
