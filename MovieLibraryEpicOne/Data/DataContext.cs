using Microsoft.EntityFrameworkCore;
using MovieLibraryEpicOne.Models;

namespace MovieLibraryEpicOne.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-F45PJ7C;Database=EpicMovieLibrary;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
