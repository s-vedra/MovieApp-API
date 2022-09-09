using MovieApp.InterfaceModels;

namespace MovieApp.Services.Abstraction
{
    public interface IUserService
    {
        void RegisterUser(RegisterUser user);
        string Authenticate(LoginUser user);
        List<User> GetUsers();
        void AddNewMovie(int id, string username);
        void RemoveMovie(int id, string username);
    }
}
