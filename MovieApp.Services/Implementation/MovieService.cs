using MovieApp.DataAccess.Repository;
using MovieApp.DomainModel;
using MovieApp.Helpers;
using MovieApp.InterfaceModels;
using MovieApp.Services.Abstraction;
using MovieApp.Services.Mappers;

namespace MovieApp.Services.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<MovieDto> _movieRepository;
        public MovieService(IRepository<MovieDto> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public void AddMovie(AddMovie movie)
        {
            if (!string.IsNullOrEmpty(movie.Title) 
                && !string.IsNullOrEmpty(movie.Genre))
            {
               _movieRepository.Add(MappingEntities.Mapper<AddMovie, MovieDto>(movie));
            }
            else
            {
                throw new MovieException();
            }
          
        }

        public List<Movie> GetByGenre(string genre)
        {
            var movies = GetMovies();
            if (movies.Any(x => x.Genre.ToLower().Contains(genre.ToLower())))
            {
                return movies.Where(x => x.Genre.ToLower().Contains(genre.ToLower())).ToList();
            }
            else
            {
                throw new MovieException(genre);
            }
        }

        public Movie GetById(int id)
        {
            var movies = GetMovies();
            if (movies.Any(x => x.Id == id))
            {
                return MappingEntities.Mapper<MovieDto, Movie>(_movieRepository.GetByID(id));
            }
            else
            {
                throw new MovieException(id);
            }
            
        }

        public List<Movie> GetMovies()
        {
            return _movieRepository.GetAll().Select(x => MappingEntities.Mapper<MovieDto, Movie>(x)).ToList();
        }
    }
}
