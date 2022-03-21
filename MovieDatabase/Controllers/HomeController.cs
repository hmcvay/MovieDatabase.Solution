using Microsoft.AspNetCore.Mvc;

namespace MovieDatabase.Controllers
{
  public class HomeController : Controllers
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}