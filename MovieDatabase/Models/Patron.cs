using System.Collections.Generic;

namespace MovieDatabase.Models
{
  public class Patron
  {

  public Patron()
  {
    this.JoinEntities = new HashSet <Rentals>();
  }
  public int PatronId { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string Address { get; set; }
  public string PhoneNumber { get; set; }
  
  public virtual ApplicationUser User { get; set; } 
  public virtual ICollection<Rentals> JoinEntities { get; set; }
  }
}