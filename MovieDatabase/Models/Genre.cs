using System.Collections.Generic;

namespace MovieDatabase.Models
{
  public class Genre
  {
    public Genre()
    {
      this.JoinEntities = new HashSet<GenreMovie>();
    }
    public int GenreId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<GenreMovie> JoinEntities { get; set; }
  }
}