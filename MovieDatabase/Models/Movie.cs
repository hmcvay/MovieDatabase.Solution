using System.Collections.Generic;
using System;

namespace MovieDatabase.Models
{
  public class Movie
  {
    public Movie()
    {
      this.JoinEntities1 = new HashSet <Rental>();
      this.JoinEntities = new HashSet <GenreMovie>();
    }
    public int MovieId { get; set; }

    public string Title { get; set; }
    public int Year { get; set; }

    public string Description { get; set; }
    public string IsCheckedOut {get; set; }
    public int RentalPrice = 3;
    // public DateTime DueBackDate = RentOutDate.AddDays(7);
    public DateTime RentOutDate { get; set; }
    public int RentalTotal { get; set; }
    public virtual ICollection<Rental> JoinEntities1{get;}
    public virtual ICollection<GenreMovie> JoinEntities{get;}
    public virtual ApplicationUser User{get;set;}
  }
}



// rental screen/form like edit form, 
//viewbag/dropdown menu customers, assign customer 
//radio/true/false is checked out 
//stock = 3; if stock =0, then "chekced out"

//REntal:
//rentalId
//movieId (join w/ genre)
//custyId (join w/ movie)