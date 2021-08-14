using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReviewApp.DAL;
using ReviewApp.Model;
using ReviewApp.Models;

namespace ReviewApp.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext _dbContext;
        private UserManager<AppUser> _userManager;
        private IHostingEnvironment _hostingEnvironment;

        public HomeController(ApplicationDbContext dbContext, UserManager<AppUser> userManager, IHostingEnvironment environment)
        {
            this._dbContext = dbContext;
            this._userManager = userManager;
            this._hostingEnvironment = environment;
        }
        public IActionResult Index()
        {
            var movies = _dbContext.Movies.Include(p => p.Director).Include(c => c.MovieGenres).ThenInclude(cs => cs.Genre)
                .Include(c => c.MovieWriters).ThenInclude(cs => cs.Writer).Include(c => c.MovieCharacters).ThenInclude(cs => cs.Character)
                .Include(c => c.MovieActors).ThenInclude(cs => cs.Actor).ThenInclude(c => c.CharacterActors).ThenInclude(c => c.Character)
                .Include(c => c.MovieStudios).ThenInclude(cs => cs.Studio).Include(r => r.UserRatings).ToList();
            var rand = new Random();
            IEnumerable<Movie> selected = movies.OrderBy(x => rand.NextDouble()).Take(6);
            return View(selected);
        }

        public ActionResult GetShows()
        {
            var shows = _dbContext.Shows.Include(c => c.ShowGenres).ThenInclude(cs => cs.Genre)
                .Include(c => c.ShowWriters).ThenInclude(cs => cs.Writer).Include(c => c.ShowCharacters).ThenInclude(cs => cs.Character)
                .Include(c => c.ShowActors).ThenInclude(cs => cs.Actor).ThenInclude(c => c.CharacterActors).ThenInclude(c => c.Character)
                .Include(c => c.ShowStudios).ThenInclude(cs => cs.Studio).Include(r => r.UserRatings).ToList();
            var rand = new Random();
            IEnumerable<Show> selected = shows.OrderBy(x => rand.NextDouble()).Take(6);
            return PartialView("_ShowsList", selected);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
