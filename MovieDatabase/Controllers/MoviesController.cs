using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace MovieDatabase.Controllers
{
  [Authorize]
  public class MoviesController : Controller
  {
    private readonly MovieDatabaseContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public MoviesController(UserManager<ApplicationUser> userManager, MovieDatabaseContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    [AllowAnonymous]
    public ActionResult Index()
    {
      return View(_db.Movies.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.GenreId = new SelectList(_db.Genres, "GenreId", "Name");
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Movie movie, int GenreId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      movie.User = currentUser;
      _db.Movies.Add(movie);
      _db.SaveChanges();
      if (GenreId != 0)
      {
        _db.GenreMovie.Add(new GenreMovie(){GenreId = GenreId, MovieId = movie.MovieId});
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisMovie = _db.Movies.FirstOrDefault(movie => movie.MovieId == id);
      return View(thisMovie);
    }

    public ActionResult Edit(int id)
    {
      var thisMovie = _db.Movies.FirstOrDefault(movie => movie.MovieId == id);
      ViewBag.GenreId = new SelectList(_db.Genres, "GenreId", "Name");
      return View(thisMovie);
    }

    [HttpPost]
    public async Task<ActionResult> Edit(Movie movie)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      movie.User = currentUser;
      _db.Entry(movie).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddGenre(int id)
    {
      var thisMovie = _db.Movies.FirstOrDefault(movie => movie.MovieId == id);
      ViewBag.GenreId = new SelectList(_db.Genres, "GenreId", "Name");
      return View(thisMovie);
    }

    [HttpPost]
    public ActionResult AddGenre(Movie movie, int GenreId)
    {
      if(GenreId != 0)
      {
        _db.GenreMovie.Add(new GenreMovie(){GenreId = GenreId, MovieId = movie.MovieId});
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      var thisMovie = _db.Movies.FirstOrDefault(movie => movie.MovieId == id);
      return View(thisMovie);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisMovie = _db.Movies.FirstOrDefault(movie => movie.MovieId == id);
      _db.Movies.Remove(thisMovie);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteGenre(int joinId)
    {
      var joinEntry = _db.GenreMovie.FirstOrDefault(entry => entry.GenreMovieId == joinId);
      _db.GenreMovie.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Rent(int id)
    {
      var thisMovie = _db.Movies.FirstOrDefault(movie=> movie.MovieId == id);
      return View(thisMovie);
    }

    [HttpPost, ActionName("Rent")]
    public async Task<ActionResult> RentMovie(Movie movie, int MovieId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var thisMovie = _db.Movies.FirstOrDefault(movie=> movie.MovieId == MovieId);
      thisMovie.User = currentUser;
      thisMovie.IsCheckedOut = "true";
      _db.Entry(thisMovie).State = EntityState.Modified;
      _db.Rentals.Add(new Rental(){MovieId = thisMovie.MovieId});
      _db.SaveChanges();
      
      return RedirectToAction("Index");
    }
  }
}



// public ActionResult DeleteConfirmed(int id)
//     {
//       var thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id);
//       _db.Items.Remove(thisItem);
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }