using MovieApp.DomainModel;

namespace MovieApp.DomainModels
{
    public class FavoriteMoviesDto
    {
        public int Id { get; set; }
        public int MovieDtoId { get; set; }
        public MovieDto MovieDto { get; set; }
    }
}
