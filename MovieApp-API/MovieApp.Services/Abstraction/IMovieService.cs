using MovieApp.InterfaceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services.Abstraction
{
    public interface IMovieService
    {
        List<Movie> GetMovies();
        Movie GetById(int id);
        List<Movie> GetByGenre(string genre);
        void AddMovie(AddMovie movie);
    }
}
