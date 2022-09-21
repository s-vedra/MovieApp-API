using AutoMapper;
using MovieApp.DomainModel;
using MovieApp.DomainModels;
using MovieApp.InterfaceModels.InterfaceModelMovies;
using MovieApp.InterfaceModels.InterfaceModelUsers;

namespace MovieApp.Services.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<User, RegisterUserDto>();
            CreateMap<RegisterUserDto, User>();
            CreateMap<User, LoginUserDto>();
            CreateMap<LoginUserDto, User>();
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>();
            CreateMap<FavoriteMovies, FavoriteMovies>();
            CreateMap<FavoriteMovies, FavoriteMovies>();
            CreateMap<AddMovieDto, Movie>();
            CreateMap<Movie, AddMovieDto>();
        }
    }
}
