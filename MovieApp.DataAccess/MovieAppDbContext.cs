using Microsoft.EntityFrameworkCore;
using MovieApp.DomainModel;
using MovieApp.DomainModels;

namespace MovieApp.DataAccess
{
    public class MovieAppDbContext : DbContext
    {
        public MovieAppDbContext(DbContextOptions<MovieAppDbContext> options) : base(options)
        {

        }

        public DbSet<MovieDto> Movies { get; set; }
        public DbSet<UserDto> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MovieDto>().ToTable("Movie");
            builder.Entity<UserDto>().ToTable("User");
            builder.Entity<UserDto>().HasData
                (
                    new UserDto()
                    {
                        Id = 1,
                        FirstName = "Bob",
                        LastName = "Bobsky",
                        Username = "bobBobsky123",
                        Password = "BobPassword", // need to hash
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
                "the Avengers must reunite and assemble again to reinvigorate their trounced allies and restore balance.",
                        UserId = 1
                    },
                    new MovieDto()
                    {
                        Id = 2,
                        Title = "Spider-Man: No Way Home",
                        Genre = "Action, Adventure, Superhero, Fantasy, SCI-FI, Comedy",
                        Year = new DateTime(2021, 12, 17),
                        Description = "Peter Parker seeks Doctor Strange's help to make people forget about Spiderman's identity. " +
                        "However, when the spell he casts gets corrupted, several unwanted guests enter their universe.",
                        UserId = 1
                    }
                );
        }
    }
}
