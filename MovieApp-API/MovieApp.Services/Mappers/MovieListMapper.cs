using MovieApp.DomainModels;
using MovieApp.InterfaceModels.InterfaceModelUsers;

namespace MovieApp.Services.Mappers
{
    public static class MovieListMapper
    {
        public static FavoriteMoviesDto ToReqModel(this FavoriteMovies list)
        {
            return new FavoriteMoviesDto()
            {
                Id = list.Id,
                Movie = list.Movie.ToReqModel()
            };
        }
        public static FavoriteMovies ToReqModel(this FavoriteMoviesDto list)
        {
            return new FavoriteMovies()
            {
                Id = list.Id,
                Movie = list.Movie.ToReqModel()
            };
        }
    }
}
