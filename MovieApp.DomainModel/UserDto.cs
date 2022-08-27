using MovieApp.DomainModel;

namespace MovieApp.DomainModels
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FavoriteGenre { get; set; }
        public virtual ICollection<MovieDto> MoviesList { get; set; }
    }
}
