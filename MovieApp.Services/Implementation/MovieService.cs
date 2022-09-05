using AutoMapper;
using MovieApp.DataAccess.Repository;
using MovieApp.DomainModel;
using MovieApp.Exceptions;
using MovieApp.InterfaceModels;
using MovieApp.Services.Abstraction;
using MovieApp.Services.Mappers;

namespace MovieApp.Services.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<MovieDto> _movieRepository;
        private readonly IMovieRepository _movieFilterRepository;
        private readonly IMapper _mapper;
        public MovieService(IRepository<MovieDto> movieRepository, IMovieRepository movieFilterRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _movieFilterRepository = movieFilterRepository;
            _mapper = mapper;
        }

        public void AddMovie(AddMovie movie)
        {
            if (!string.IsNullOrEmpty(movie.Title)
                && !string.IsNullOrEmpty(movie.Genre))
            {
                _movieRepository.Add(_mapper.Map<MovieDto>(movie));
            }
            else
            {
                throw new MovieException("Movie name is required");
            }

        }

        public List<Movie> GetByGenre(string genre)
        {
            var movies = _movieFilterRepository.GetByGenre(genre);
            if (movies.Count() != 0)
            {
                return movies.Select(x => _mapper.Map<Movie>(x)).ToList();
            }
            else
            {
                throw new MovieException("No movies found");
            }
        }

        public Movie GetById(int id)
        {
            Movie movie = _mapper.Map<Movie>(_movieRepository.GetByID(id));
            if (movie != null)
            {
                return _mapper.Map<Movie>(_movieRepository.GetByID(id));
            }
            else
            {
                throw new MovieException("Movie doesn't exist");
            }

        }

        public List<Movie> GetMovies()
        {
            var movies  = _movieRepository.GetAll().Select(x => _mapper.Map<Movie>(x.Value)).ToList();
            if (movies.Count != 0)
            {
                return movies;
            }
            else
            {
                throw new MovieException("No movies found");
            }
            
        }
    }
}
