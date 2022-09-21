using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.DataAccess;
using MovieApp.DataAccess.Implementation;
using MovieApp.DataAccess.Repository;
using MovieApp.DomainModel;
using MovieApp.DomainModels;
using MovieApp.HelperMethods;
using MovieApp.Services.Abstraction;
using MovieApp.Services.Implementation;
using MovieApp.Services.Mappers;

namespace MovieApp.Utilities
{
    public static class DependencyInjUtility
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection service, string connectionString)
        {
            //dbConnection
            service.AddDbContext<MovieAppDbContext>(options =>
            options.UseSqlServer(connectionString)
            );
            //services
            service.AddTransient<IRepository<Movie>, MovieRepository>();
            service.AddTransient<IMovieService, MovieService>();
            service.AddTransient<IRepository<User>, UserRepository>();
            service.AddTransient<IUserService, UserService>();
            service.AddTransient<IMovieRepository, MovieRepository>();
            service.AddTransient<IUserRepository, UserRepository>();
            service.AddTransient<IHasher, Hashing>();
            //helpers
            service.AddTransient<IGenerateToken, GenerateToken>();
            //mapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            service.AddSingleton(mapper);
            return service;
        }
    }
}