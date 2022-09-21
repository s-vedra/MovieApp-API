using MovieApp.InterfaceModels.InterfaceModelMovies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services.Abstraction
{
    public interface IMovieService
    {
        List<MovieDto> GetMovies();
        MovieDto GetById(int id);
        List<MovieDto> GetByGenre(string genre);
        void AddMovie(AddMovieDto movie);
        void DeleteMovie(int id);
        void UpdateMovie(UpdateMovieDto movie);
    }
}
