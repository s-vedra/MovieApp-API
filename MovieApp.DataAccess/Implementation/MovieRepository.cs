using MovieApp.DataAccess.Repository;
using MovieApp.DomainModel;

namespace MovieApp.DataAccess.Implementation
{
    public class MovieRepository : IRepository<MovieDto>
    {
        private readonly MovieAppDbContext _dbContext;
        public MovieRepository(MovieAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(MovieDto entity)
        {
            //entity.Id = ++MovieStaticDb.Counter;
            _dbContext.Movies.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(MovieDto entity)
        {
            _dbContext.Movies.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<MovieDto> GetAll()
        {
            return _dbContext.Movies;
        }

        public MovieDto GetByID(int id)
        {
            return _dbContext.Movies.SingleOrDefault(x => x.Id == id);
        }

        public void Update(MovieDto entity)
        {
          MovieDto movie = GetByID(entity.Id);
            if (movie != null)
            {
                _dbContext.Entry(movie).CurrentValues.SetValues(entity);
                _dbContext.SaveChanges();
            }
        }
    }
}
