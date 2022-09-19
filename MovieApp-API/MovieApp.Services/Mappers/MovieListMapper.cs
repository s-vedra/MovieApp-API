using MovieApp.DomainModel;
using MovieApp.DomainModels;
using MovieApp.InterfaceModels.InterfaceModelUsers;

namespace MovieApp.Services.Mappers
{
    public static class MovieListMapper
    {
        public static FavoriteMovies ToReqModel(this FavoriteMoviesDto list)
        {
            return new FavoriteMovies()
            {
                Id = list.Id,
                Movie = list.MovieDto.ToReqModel()
            };
        }
        public static FavoriteMoviesDto ToReqModel(this FavoriteMovies list)
        {
            return new FavoriteMoviesDto()
            {
                Id = list.Id,
                MovieDto = list.Movie.ToReqModel()
            };
        }
    }
}
