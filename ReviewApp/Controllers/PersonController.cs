using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReviewApp.DAL;
using ReviewApp.Model;

namespace ReviewApp.Web.Controllers
{
    public class PersonController : Controller
    {

        private ApplicationDbContext _dbContext;
        private UserManager<AppUser> _userManager;
        private IHostingEnvironment _hostingEnvironment;

        public PersonController(ApplicationDbContext dbContext, UserManager<AppUser> userManager, IHostingEnvironment environment)
        {
            this._dbContext = dbContext;
            this._userManager = userManager;
            this._hostingEnvironment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int? id = null)
        {
            var person = _dbContext.People
                .Include(c => c.ShowWriters).ThenInclude(cs => cs.Show).Include(c => c.CharacterActors).ThenInclude(cs => cs.Character)
                .Include(c => c.ShowActors).ThenInclude(cs => cs.Show).Include(c => c.MovieWriters).ThenInclude(c => c.Movie)
                .Include(c => c.MovieActors).ThenInclude(cs => cs.Movie).Where(p => p.ID == id).FirstOrDefault();


            return View(person);
        }
    }
}