using MovieApp.InterfaceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services.Abstraction
{
    public interface IUserService
    {
        void RegisterUser(RegisterUser user);
        void Authenticate(LoginUser user);
        List<User> GetUsers();
        void AddNewMovie(AddFavoriteMovie list);
        User GetById(int id);
    }
}
