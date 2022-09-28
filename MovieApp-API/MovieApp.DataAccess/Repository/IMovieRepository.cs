using MovieApp.DomainModel;
using MovieApp.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DataAccess.Repository
{
    public interface IMovieRepository : IRepository<Movie>
    {
        IEnumerable<Movie> GetByGenre(string genre);
        Movie GetByName(string name);
        FavoriteMovies GetFavMovie(int id);
    }
}
