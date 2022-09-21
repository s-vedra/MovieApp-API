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
        public static InterfaceModels.InterfaceModelUsers.UserDto ToReqModel(this DomainModels.User source)
        {
            return new InterfaceModels.InterfaceModelUsers.UserDto()
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
        public static DomainModels.User ToReqModel(this InterfaceModels.InterfaceModelUsers.UserDto source)
        {
            return new DomainModels.User()
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
