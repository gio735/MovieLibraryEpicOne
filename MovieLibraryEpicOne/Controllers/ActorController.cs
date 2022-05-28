using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieLibraryEpicOne.Data;
using MovieLibraryEpicOne.Models;

namespace MovieLibraryEpicOne.Controllers
{
    public class ActorController : Controller
    {

        public ActorController()
        {

        }
        [HttpGet("Actors")]
        public IActionResult Index(string name = "", string lastname = "", double minRating = 0, double maxRating = 10)
        {
            var actors = new List<Actor>();
            using (var context = new DataContext())
            {
                actors = context.Actors.Include(e => e.Movies).Where(e => e.Rating >= minRating && e.Rating <= maxRating).ToList();
            }
            if(name != "")
            {
                actors = actors.Where(e => e.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            if(lastname != "")
            {
                actors = actors.Where(e => e.Lastname.Contains(lastname, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            return View(actors);
        }
        [Route("Actor/View/{id:int}")]
        public IActionResult ActorInfo(int id) 
        {
            Actor actor;
            using (var context = new DataContext())
            {
                 actor = context.Actors.Include(e => e.Movies).Where(e => e.Id == id).FirstOrDefault();
            }
            return View(actor);
        }
    }
}
