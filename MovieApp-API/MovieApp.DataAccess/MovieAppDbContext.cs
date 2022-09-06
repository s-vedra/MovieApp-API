using Microsoft.EntityFrameworkCore;
using MovieApp.DomainModel;
using MovieApp.DomainModels;
using MovieApp.HelperMethods;

namespace MovieApp.DataAccess
{
    public class MovieAppDbContext : DbContext
    {
        public MovieAppDbContext(DbContextOptions<MovieAppDbContext> options) : base(options)
        {

        }

        public DbSet<MovieDto> Movies { get; set; }
        public DbSet<UserDto> Users { get; set; }
        public DbSet<FavoriteMoviesDto> MovieList { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MovieDto>().ToTable("Movie");
            builder.Entity<UserDto>().ToTable("User");
            builder.Entity<FavoriteMoviesDto>().ToTable("MovieList");
            builder.Entity<UserDto>().HasData
                (
                    new UserDto()
                    {
                        Id = 1,
                        FirstName = "Bob",
                        LastName = "Bobsky",
                        Username = "bobBobsky123",
                        Password = "BobPassword".Hash(),
                        FavoriteGenre = "Action", 
                    }
                );
            builder.Entity<MovieDto>().HasData
                (
                    new MovieDto()
                    {
                        Id = 1,
                        Title = "Avengers: Endgame",
                        Genre = "Action, Adventure, Superhero, Fantasy, SCI-FI",
                        Year = new DateTime(2019, 4, 26),
                        Description = "After Thanos, an intergalactic warlord, disintegrates half of the universe, " +
                "the Avengers must reunite and assemble again to reinvigorate their trounced allies and restore balance."
                    },
                    new MovieDto()
                    {
                        Id = 2,
                        Title = "Spider-Man: No Way Home",
                        Genre = "Action, Adventure, Superhero, Fantasy, SCI-FI, Comedy",
                        Year = new DateTime(2021, 12, 17),
                        Description = "Peter Parker seeks Doctor Strange's help to make people forget about Spiderman's identity. " +
                        "However, when the spell he casts gets corrupted, several unwanted guests enter their universe."
                    }
                );
        }
    }
}
