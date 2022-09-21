using MovieApp.InterfaceModels.InterfaceModelMovies;

namespace MovieApp.InterfaceModels.InterfaceModelUsers
{
    public class FavoriteMoviesDto
    {
        public int Id { get; set; }
        public MovieDto Movie { get; set; }
    }
}
