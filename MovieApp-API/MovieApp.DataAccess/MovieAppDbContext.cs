using Microsoft.EntityFrameworkCore;
using MovieApp.DomainModel;
using MovieApp.DomainModels;
using MovieApp.HelperMethods;

namespace MovieApp.DataAccess
{
    public class MovieAppDbContext : DbContext
    {
        private readonly IHasher _hasher;
        public MovieAppDbContext(DbContextOptions<MovieAppDbContext> options, IHasher hasher) : base(options)
        {
            _hasher = hasher;
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FavoriteMovies> MovieList { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Movie>().ToTable("Movie");
            builder.Entity<User>().ToTable("User");
            builder.Entity<FavoriteMovies>().ToTable("MovieList");
            builder.Entity<User>().HasData
                (
                    new User()
                    {
                        Id = 1,
                        FirstName = "Bob",
                        LastName = "Bobsky",
                        Username = "bobBobsky123",
                        Password = _hasher.Hash("BobPassword"),
                        FavoriteGenre = "Action", 
                    }
                );
            builder.Entity<Movie>().HasData
                (
                    new Movie()
                    {
                        Id = 1,
                        Title = "Avengers: Endgame",
                        Genre = "Action, Adventure, Superhero, Fantasy, SCI-FI",
                        Year = new DateTime(2019, 4, 26),
                        Description = "After Thanos, an intergalactic warlord, disintegrates half of the universe, " +
                "the Avengers must reunite and assemble again to reinvigorate their trounced allies and restore balance."
                    },
                    new Movie()
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
