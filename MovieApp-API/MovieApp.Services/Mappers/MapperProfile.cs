using AutoMapper;
using MovieApp.DomainModel;
using MovieApp.DomainModels;
using MovieApp.InterfaceModels;

namespace MovieApp.Services.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, RegisterUser>();
            CreateMap<RegisterUser, UserDto>();
            CreateMap<UserDto, LoginUser>();
            CreateMap<LoginUser, UserDto>();
            CreateMap<MovieDto, Movie>();
            CreateMap<Movie, MovieDto>();
            CreateMap<FavoriteMovies, FavoriteMoviesDto>();
            CreateMap<FavoriteMoviesDto, FavoriteMovies>();
            CreateMap<AddMovie, MovieDto>();
            CreateMap<MovieDto, AddMovie>();
        }
    }
}
