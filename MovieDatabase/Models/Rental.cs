using System;
namespace MovieDatabase.Models
{
  public class Rental
  {
    public int RentalId { get; set; }
    public int MovieId{ get; set; }
    public int PatronId{ get; set; }
    public DateTime DateRented { get; set; }
    public DateTime DueDate { get; set; }
    public int RentalTotal { get; set; }

    public virtual Movie Movie { get; set; }
    public virtual Patron Patron { get; set; }
  }
}  
  
  
  
  
  // rental id
  // movie id
  // patron id
  // date out
  // date to return
  // amount due
