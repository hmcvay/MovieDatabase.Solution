using System.Collections.Generic;

namespace MovieDatabase.Models
{
  public class Movie
  {
    public Movie()
    {
      // this.JoinEntities = new HashSet <Rental>();
      this.JoinEntities = new HashSet <GenreMovie>();
    }
    public int MovieId { get; set; }

    public string Title { get; set; }
    public int Year { get; set; }

    public string Description { get; set; }
    public virtual ApplicationUser User {get; set; }
    // public virtual ICollection<Rental> JoinEntities{get;}
    public virtual ICollection<GenreMovie> JoinEntities{get;}
  }
}