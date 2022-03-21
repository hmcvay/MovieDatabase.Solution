using System.Collections.Generic;

namespace MovieDatabase.Models
{
  public class Movie
  {
    public Movie()
    {
      this.JoinEntities = new HashSet <Rentals>();
    }
    public int MovieId { get; set; }

    public string Title { get; set; }
    public int Year { get; set; }
    public string Description { get; set; }
    public virtual ICollection<Rentals> JoinEntities{get;}
  }
}