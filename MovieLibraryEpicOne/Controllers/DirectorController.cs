using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieLibraryEpicOne.Data;
using MovieLibraryEpicOne.Models;

namespace MovieLibraryEpicOne.Controllers
{
    public class DirectorController : Controller
    {
        public DirectorController()
        {

        }
        [HttpGet("Directors")]
        public IActionResult Index(string name = "", string lastname = "", double minRating = 0, double maxRating = 10)
        {
            var directors = new List<Director>();
            using (var context = new DataContext())
            {
                directors = context.Directors.Include(e => e.Movies).Where(e => e.Rating >= minRating && e.Rating <= maxRating).ToList();
            }
            if (name != "")
            {
                directors = directors.Where(e => e.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            if (lastname != "")
            {
                directors = directors.Where(e => e.Lastname.Contains(lastname, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            return View(directors);
        }

        [NonAction]
        public static List<Director> GetDirectors()
        {
            List<Director> result;
            using(var context = new DataContext())
            {
                result = context.Directors.ToList();
            }
            return result;
        }
        [Route("Director/View/{id:int}")]
        public IActionResult DirectorInfo(int id)
        {
            Director result;
            using (var context = new DataContext())
            {
                result = context.Directors.Include(e => e.Movies).Where(e => e.Id == id).FirstOrDefault();
            }
            return View(result);
        }
    }
}
