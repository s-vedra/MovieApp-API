using MovieApp.DomainModel;
using MovieApp.DomainModels;
using MovieApp.InterfaceModels;
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
                MoviesList = source.MoviesList.Select(x => MappingEntities.Mapper<MovieDto, Movie>(x)).ToList()
            };
        }
    }
}
