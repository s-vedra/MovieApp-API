using Microsoft.EntityFrameworkCore;
using MovieApp.DataAccess.Repository;
using MovieApp.DomainModel;
using MovieApp.DomainModels;

namespace MovieApp.DataAccess.Implementation
{
    public class MovieRepository : IRepository<Movie>, IMovieRepository
    {
        private readonly MovieAppDbContext _dbContext;
        public MovieRepository(MovieAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Movie entity)
        {
            _dbContext.Movies.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Movie entity)
        {
            _dbContext.Movies.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IDictionary<string, Movie> GetAll()
        {
            return _dbContext.Movies.ToDictionary(x => x.Id.ToString(), x=> x);
        }

        public IEnumerable<Movie> GetByGenre(string genre)
        {  
           return GetAll().Values.Where(x => x.Genre.ToLower().Contains(genre.ToLower())); 
        }

        public Movie GetByID(int id)
        {
            return GetAll().SingleOrDefault(x => x.Key == id.ToString()).Value;
        }

        public Movie GetByName(string name)
        {
            return GetAll().SingleOrDefault(x => x.Value.Title.ToLower().Contains(name.ToLower())).Value;
        }

        public FavoriteMovies GetFavMovie(int id)
        {
            return _dbContext.MovieList.SingleOrDefault(x => x.Id == id);
        }

        public void Update(Movie entity)
        {
          Movie movie = GetByID(entity.Id);
          _dbContext.Entry(movie).CurrentValues.SetValues(entity);
          _dbContext.SaveChanges();
        }
    }
}
