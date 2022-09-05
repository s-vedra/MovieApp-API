namespace MovieApp.HelperMethods
{
    public interface IGenerateToken
    {
        string Token(int id, string username);
    }
}
