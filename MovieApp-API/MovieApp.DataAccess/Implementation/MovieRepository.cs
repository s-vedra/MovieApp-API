using Microsoft.EntityFrameworkCore;
using MovieApp.DataAccess.Repository;
using MovieApp.DomainModel;
using MovieApp.DomainModels;

namespace MovieApp.DataAccess.Implementation
{
    public class MovieRepository : IRepository<MovieDto>, IMovieRepository
    {
        private readonly MovieAppDbContext _dbContext;
        public MovieRepository(MovieAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(MovieDto entity)
        {
            _dbContext.Movies.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(MovieDto entity)
        {
            _dbContext.Movies.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IDictionary<string, MovieDto> GetAll()
        {
            return _dbContext.Movies.ToDictionary(x => x.Id.ToString(), x=> x);
        }

        public IEnumerable<MovieDto> GetByGenre(string genre)
        {  
           return GetAll().Values.Where(x => x.Genre.ToLower().Contains(genre.ToLower())); 
        }

        public MovieDto GetByID(int id)
        {
            return GetAll().SingleOrDefault(x => x.Key == id.ToString()).Value;
        }

        public MovieDto GetByName(string name)
        {
            return GetAll().SingleOrDefault(x => x.Value.Title.ToLower().Contains(name.ToLower())).Value;
        }

        public FavoriteMoviesDto GetFavMovie(int id)
        {
            return _dbContext.MovieList.SingleOrDefault(x => x.Id == id);
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
