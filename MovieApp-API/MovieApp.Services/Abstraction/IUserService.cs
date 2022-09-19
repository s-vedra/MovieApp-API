using MovieApp.InterfaceModels.InterfaceModelUsers;

namespace MovieApp.Services.Abstraction
{
    public interface IUserService
    {
        void RegisterUser(RegisterUser user);
        string Authenticate(LoginUser user);
        List<User> GetUsers();
        void AddNewMovie(int id, string username);
        void RemoveMovie(int id, string username);
        void ForgotPassword(UpdateUser user);
    }
}
