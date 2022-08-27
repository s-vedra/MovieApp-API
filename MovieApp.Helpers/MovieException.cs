namespace MovieApp.Helpers
{
    public class MovieException : Exception
    {
        public MovieException() : base("Something went wrong")
        {

        }
        public MovieException(int id) : base($"The movie with the id {id} doesn't exist")
        {

        }
        public MovieException(string genre) : base($"No movies found with {genre} genre")
        {

        }
    }
}