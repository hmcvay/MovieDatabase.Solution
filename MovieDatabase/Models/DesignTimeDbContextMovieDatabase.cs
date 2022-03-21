using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MovieDatabase.Models
{
  public class MovieDatabaseContextFactory : IDesignTimeDbContextFactory<MovieDatabaseContext>
  {

    MovieDatabaseContext IDesignTimeDbContextFactory<MovieDatabaseContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<MovieDatabaseContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new MovieDatabaseContext(builder.Options);
    }
  }
}