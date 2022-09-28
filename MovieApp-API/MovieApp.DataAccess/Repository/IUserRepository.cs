using MovieApp.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DataAccess.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUser(string username);
    }
}
