namespace MovieApp.Exceptions
{
    public class UserException : Exception
    {
        public UserException() : base("Something went wrong")
        {

        }
        public UserException(string message) : base(message)
        {

        }
    }
}
