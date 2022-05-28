using Microsoft.AspNetCore.Mvc;

namespace MovieLibraryEpicOne.Controllers
{
    public class GenreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
