using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieDatabase.Controllers

{
  public class GenresController : Controller
  {
    private readonly MovieDatabaseContext _db;

    public GenresController(MovieDatabaseContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Genre> model = _db.Genres.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Genre genre)
    {
      _db.Genres.Add(genre);
      _db.SaveChanges();
      return RedirectToAction("Index"); 
    }

    public ActionResult Details(int id)
    {
      var thisGenre = _db.Genres
        .Include(genre => genre.JoinEntities)
        .ThenInclude(join => join.Movie)
        .FirstOrDefault(genre => genre.GenreId == id);
      return View(thisGenre);
    }

    public ActionResult Delete(int id)
    {
      var thisGenre = _db.Genres.FirstOrDefault(genre => genre.GenreId == id);
      return View(thisGenre);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisGenre = _db.Genres.FirstOrDefault(genre => genre.GenreId == id);
      _db.Genres.Remove(thisGenre);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}