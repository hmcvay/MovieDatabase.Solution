using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MovieDatabase.Models
{
  public class ApplicationUser : IdentityUser
  {
    public ApplicationUser()
    {
      this.JoinEntities = new HashSet<Rental>();
    }

    public virtual ICollection<Rental> JoinEntities{get;set;}
  }
}