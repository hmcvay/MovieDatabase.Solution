using System.ComponentModel.DataAnnotations;

namespace MovieDatabase.ViewModels
{
  public class PatronRegisterViewModel
  {
    [Required]
    [FirstName]
    [Display(Name = "First Name")]

    [Required]
  }
}


// public string FirstName { get; set; }
//   public string LastName { get; set; }
//   public string Address { get; set; }
//   public string PhoneNumber { get; set; }