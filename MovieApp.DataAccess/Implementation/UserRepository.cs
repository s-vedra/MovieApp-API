using Microsoft.EntityFrameworkCore;
using MovieApp.DataAccess.Repository;
using MovieApp.DomainModels;

namespace MovieApp.DataAccess.Implementation
{
    public class UserRepository : IRepository<UserDto>
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

        public IEnumerable<UserDto> GetAll()
        {
           return _dbContext.Users.Include(x => x.MoviesList);
        }

        public UserDto GetByID(int id)
        {
            return _dbContext.Users.Include(x => x.MoviesList).SingleOrDefault(x => x.Id == id);
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
