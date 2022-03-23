using System;
namespace MovieDatabase.Models
{
  public class Rental
  {
    public int RentalId { get; set; }
    public int MovieId{ get; set; }
    public virtual Movie Movie { get; set; }
    
  }
}
  // rental id
  // movie id
  // patron id
  // date out
  // date to return