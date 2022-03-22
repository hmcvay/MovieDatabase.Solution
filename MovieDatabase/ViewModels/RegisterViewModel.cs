using System.ComponentModel.DataAnnotations;

namespace MovieDatabase.ViewModels
{
  public class PatronRegisterViewModel
  {
    [Required]
    [FirstName]
    [Display(Name = "First Name")]
    public string FirstName {get;set;}

    [Required]
    [LastName]
    [Display(Name = "Last Name")]

    [Required]
    [Address]
    [Display(Name = "Address")]

    [Required]
    [PhoneNumber]
    [Display(Name = "Phone Number")]
  }
}


// public string FirstName { get; set; }
//   public string LastName { get; set; }
//   public string Address { get; set; }
//   public string PhoneNumber { get; set; }