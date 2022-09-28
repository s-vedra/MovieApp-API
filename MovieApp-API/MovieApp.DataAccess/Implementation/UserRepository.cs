using Microsoft.EntityFrameworkCore;
using MovieApp.DataAccess.Repository;
using MovieApp.DomainModels;

namespace MovieApp.DataAccess.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly MovieAppDbContext _dbContext;
        public UserRepository(MovieAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(User entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(User entity)
        {
            _dbContext.Users.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IDictionary<string,User> GetAll()
        {
           return _dbContext.Users.Include(x => x.MoviesList).ThenInclude(x => x.Movie).ToDictionary(x => x.Username, x=> x);
        }

        public User GetByID(int id)
        {
            return GetAll().Values.SingleOrDefault(x => x.Id == id);
        }

        public User GetUser(string username)
        {
            return GetAll().Values.SingleOrDefault(x => x.Username == username);
        }

        public void Update(User entity)
        {
            User movie = GetByID(entity.Id);
            _dbContext.Entry(movie).CurrentValues.SetValues(entity);
            _dbContext.SaveChanges();
        }
    }
}
