using AutoMapper;
using MovieApp.DataAccess.Repository;
using MovieApp.DomainModel;
using MovieApp.Exceptions;
using MovieApp.InterfaceModels.InterfaceModelMovies;
using MovieApp.Services.Abstraction;

namespace MovieApp.Services.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _movieRepository;
        private readonly IMovieRepository _movieFilterRepository;
        private readonly IMapper _mapper;
        public MovieService(IRepository<Movie> movieRepository, IMovieRepository movieFilterRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _movieFilterRepository = movieFilterRepository;
            _mapper = mapper;
        }

        public void AddMovie(AddMovieDto movie)
        {
            if (!string.IsNullOrEmpty(movie.Title)
                && !string.IsNullOrEmpty(movie.Genre))
            {
                _movieRepository.Add(_mapper.Map<Movie>(movie));
            }
            else
            {
                throw new MovieException("Movie name is required");
            }

        }

        public void DeleteMovie(int id)
        {
            var movie = _movieRepository.GetByID(id);
            if (movie != null)
            {
                _movieRepository.Delete(movie);
            }
            else
            {
                throw new MovieException("No movie found");
            }

        }

        public List<MovieDto> GetByGenre(string genre)
        {
            var movies = _movieFilterRepository.GetByGenre(genre);
            if (movies.Count() != 0)
            {
                return movies.Select(x => _mapper.Map<MovieDto>(x)).ToList();
            }
            else
            {
                throw new MovieException("No movies found");
            }
        }

        public MovieDto GetById(int id)
        {
            Movie movie = _movieRepository.GetByID(id);
            if (movie != null)
            {
                return _mapper.Map<MovieDto>(_movieRepository.GetByID(id));
            }
            else
            {
                throw new MovieException("Movie doesn't exist");
            }

        }

        public List<MovieDto> GetMovies()
        {
            var movies = _movieRepository.GetAll().Select(x => _mapper.Map<MovieDto>(x.Value)).ToList();
            if (movies.Count != 0)
            {
                return movies;
            }
            else
            {
                throw new MovieException("No movies found");
            }

        }

        public void UpdateMovie(UpdateMovieDto movieModel)
        {
            var filteredMovie = _movieRepository.GetByID(movieModel.Id);
            if (filteredMovie != null)
            {
                Movie movie = new()
                {
                    Id = movieModel.Id,
                    Title = movieModel.Title,
                    Genre = movieModel.Genre,
                    Description = movieModel.Description,
                    Year = movieModel.Year
                };
                _movieRepository.Update(movie);
            }
            else
            {
                throw new MovieException("No movie found");
            }

        }
    }
}
