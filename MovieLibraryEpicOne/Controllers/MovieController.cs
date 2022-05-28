using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;
using Microsoft.EntityFrameworkCore;
using MovieLibraryEpicOne.Data;
using MovieLibraryEpicOne.Models;

namespace MovieLibraryEpicOne.Controllers
{
    public class MovieController : Controller
    {
        public MovieController()
        {

        }
        [HttpGet("Movies")]
        public IActionResult Index(string name = "", double minIMDB = 0, double maxIMDB = 10, int minTomato = 0, int maxTomato = 100, string genre = "")
        {
            List<Movie> result;
            using (var context = new DataContext())
            {
                result = context.Movies.Include(e => e.Actors).ThenInclude(e => e.Movies)
                    .Include(e => e.MainGenre)
                    .Include(e => e.LeadDirector)
                    .Where(e => e.Name.Contains(name) && e.IMDB >= minIMDB && e.IMDB <= maxIMDB && e.RottenTomatoes >= minTomato && e.RottenTomatoes <= maxTomato).ToList();

                if (genre != "")
                {
                    result = result.Where(e => e.MainGenre.Name == genre).ToList();
                }
            }
            return View(result);
        }

        [Route("Movie/View/{id:int}")]
        public IActionResult MovieInfo(int id)
        {
            Movie? movie;
            using (var context = new DataContext())
            {
                movie = context.Movies.Include(e => e.LeadDirector).Include(e => e.Actors).Where(e => e.Id == id).FirstOrDefault();
                
            }
            return View(movie);
        }

        public static void NoMovie()
        {
            
        }
    }
}
