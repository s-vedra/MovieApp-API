namespace MovieApp.Exceptions
{
    public class MovieException : Exception
    {
        public MovieException() : base("Something went wrong")
        {

        }
        public MovieException(string message) : base(message)
        {

        }
    }
}