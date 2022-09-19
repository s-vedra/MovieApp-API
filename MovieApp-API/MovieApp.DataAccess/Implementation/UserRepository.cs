using Microsoft.EntityFrameworkCore;
using MovieApp.DataAccess.Repository;
using MovieApp.DomainModels;

namespace MovieApp.DataAccess.Implementation
{
    public class UserRepository : IRepository<UserDto>, IUserRepository
    {
        private readonly MovieAppDbContext _dbContext;
        public UserRepository(MovieAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(UserDto entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(UserDto entity)
        {
            _dbContext.Users.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IDictionary<string,UserDto> GetAll()
        {
           return _dbContext.Users.Include(x => x.MoviesList).ThenInclude(x => x.MovieDto).ToDictionary(x => x.Username, x=> x);
        }

        public UserDto GetByID(int id)
        {
            return GetAll().Values.SingleOrDefault(x => x.Id == id);
        }

        public UserDto GetUser(string username)
        {
            return GetAll().Values.SingleOrDefault(x => x.Username == username);
        }

        public void Update(UserDto entity)
        {
            UserDto movie = GetByID(entity.Id);
            if (movie != null)
            {
                _dbContext.Entry(movie).CurrentValues.SetValues(entity);
                _dbContext.SaveChanges();
            }
        }
    }
}
