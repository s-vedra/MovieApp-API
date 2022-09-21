using MovieApp.DomainModel;

namespace MovieApp.DomainModels
{
    public class FavoriteMovies
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
