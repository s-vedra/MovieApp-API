using MovieApp.DomainModel;
using MovieApp.InterfaceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services.Mappers
{
    public static class MovieMapper
    {
        public static Movie ToReqModel(this MovieDto movie)
        {
            return new Movie()
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Year = movie.Year,
                Genre = movie.Genre
            };
        }
        public static MovieDto ToReqModel(this Movie movie)
        {
            return new MovieDto()
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Year = movie.Year,
                Genre = movie.Genre
            };
        }
    }
}
