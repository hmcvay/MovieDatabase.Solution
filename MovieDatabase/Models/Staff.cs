namespace MovieDatabase.Models
{
  public class Staff : IdentityUser
  {
    public int StaffId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public virtual ApplicationUser User { get; set; } 

  }
}