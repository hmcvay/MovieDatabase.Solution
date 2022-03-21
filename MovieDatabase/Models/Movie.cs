using System.Collections.Generic;

namespace MovieDatabase.Models
{
  public class Movie
  {
    public Movie()
    {
      this.JoinEntities = new HashSet <Rentals>();
      this.JoinEntities1 = new HashSet <GenreMovie>();
    }
    public int MovieId { get; set; }

    public string Title { get; set; }
    public int Year { get; set; }

    public string Description { get; set; }
    public virtual ICollection<Rentals> JoinEntities{get;}
    public virtual ICollection<GenreMovie> JoinEntities1{get;}
  }
}