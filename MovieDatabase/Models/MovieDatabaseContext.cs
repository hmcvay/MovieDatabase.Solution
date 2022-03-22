using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MovieDatabase.Models
{
  public class MovieDatabaseContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }
    // public DbSet<Rental> Rentals { get; set; }
    public DbSet<GenreMovie> GenreMovie { get; set; }
    public MovieDatabaseContext(DbContextOptions options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}