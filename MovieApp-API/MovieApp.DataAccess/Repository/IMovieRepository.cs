using MovieApp.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DataAccess.Repository
{
    public interface IMovieRepository
    {
        IEnumerable<MovieDto> GetByGenre(string genre);
        MovieDto GetByName(string name);
    }
}
