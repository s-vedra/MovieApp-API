using MovieApp.InterfaceModels.InterfaceModelUsers;

namespace MovieApp.Services.Abstraction
{
    public interface IUserService
    {
        void RegisterUser(RegisterUserDto user);
        string Authenticate(LoginUserDto user);
        List<UserDto> GetUsers();
        void AddNewMovie(int id, string username);
        void RemoveMovie(int id, string username);
        void ForgotPassword(UpdateUserDto user);
    }
}
