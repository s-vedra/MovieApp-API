using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.DataAccess;
using MovieApp.DataAccess.Implementation;
using MovieApp.DataAccess.Repository;
using MovieApp.DomainModel;
using MovieApp.DomainModels;
using MovieApp.Services.Abstraction;
using MovieApp.Services.Implementation;

namespace MovieApp.Utilities
{
    public static class DependencyInjUtility
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection service, string connectionString)
        {
            service.AddDbContext<MovieAppDbContext>(options =>
            options.UseSqlServer(connectionString)
            );
            service.AddTransient<IRepository<MovieDto>, MovieRepository>();
            service.AddTransient<IMovieService, MovieService>();
            service.AddTransient<IRepository<UserDto>, UserRepository>();
            service.AddTransient<IUserService, UserService>();
            return service;
        }
    }
}