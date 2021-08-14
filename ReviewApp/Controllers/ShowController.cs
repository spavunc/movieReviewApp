using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.DAL;
using ReviewApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ReviewApp.Web.Models;

namespace ReviewApp.Web.Controllers
{
    public class ShowController : Controller
    {
        private ApplicationDbContext _dbContext;
        private UserManager<AppUser> _userManager;
        private IHostingEnvironment _hostingEnvironment;

        public ShowController(ApplicationDbContext dbContext, UserManager<AppUser> userManager, IHostingEnvironment environment)
        {
            this._dbContext = dbContext;
            this._userManager = userManager;
            this._hostingEnvironment = environment;
        }
        [Route("Shows")]
        public IActionResult Index()
        {
            var shows = _dbContext.Shows.Include(c => c.ShowGenres).ThenInclude(cs => cs.Genre)
                .Include(c => c.ShowWriters).ThenInclude(cs => cs.Writer).Include(c => c.ShowCharacters).ThenInclude(cs => cs.Character)
                .Include(c => c.ShowActors).ThenInclude(cs => cs.Actor).ThenInclude(c => c.CharacterActors).ThenInclude(c => c.Character)
                .Include(c => c.ShowStudios).ThenInclude(cs => cs.Studio).Include(r => r.UserRatings).ToList();
            return View(shows);
        }

        [HttpPost]
        public ActionResult IndexAjax(ShowFilterModel filter)
        {
            var showQuery = _dbContext.Shows.Include(c => c.ShowGenres).ThenInclude(cs => cs.Genre)
                .Include(c => c.ShowWriters).ThenInclude(cs => cs.Writer).Include(c => c.ShowCharacters).ThenInclude(cs => cs.Character)
                .Include(c => c.ShowActors).ThenInclude(cs => cs.Actor).ThenInclude(c => c.CharacterActors).ThenInclude(c => c.Character)
                .Include(c => c.ShowStudios).ThenInclude(cs => cs.Studio).Include(r => r.UserRatings).AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Name))
                showQuery = showQuery.Where(p => (p.Title).Contains(filter.Name));


            var model = showQuery.ToList();
            return PartialView("_IndexTable", model);
        }

        public IActionResult Details(int? id = null)
        {
            var show = _dbContext.Shows.Include(c => c.ShowGenres).ThenInclude(cs => cs.Genre)
                .Include(c => c.ShowWriters).ThenInclude(cs => cs.Writer).Include(c => c.ShowCharacters).ThenInclude(cs => cs.Character)
                .Include(c => c.ShowActors).ThenInclude(cs => cs.Actor).ThenInclude(c => c.CharacterActors).ThenInclude(c => c.Character)
                .Include(c => c.ShowStudios).ThenInclude(cs => cs.Studio).Include(r => r.UserRatings).Where(p => p.ID == id).FirstOrDefault();

            var ratings = _dbContext.Ratings.Include(m => m.Movie).Include(u => u.User).ToList();
            var currentUser = this._userManager.GetUserId(base.User);
            foreach (var rating in ratings)
            {
                foreach (var model in show.UserRatings)
                {
                    if (model.ShowID == rating.ShowID && currentUser == rating.UserID)
                    {
                        ViewBag.Rating = rating.Score;
                        return View(show);
                    }
                }
            }

            return View(show);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(Show model)
        {
            if (ModelState.IsValid)
            {
                this._dbContext.Add(model);
                this._dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [Authorize(Roles = "Admin")]
        [ActionName(nameof(Edit))]
        public IActionResult Edit(int id)
        {
            var model = this._dbContext.Shows.FirstOrDefault(c => c.ID == id);
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ActionName(nameof(Edit))]
        public async Task<IActionResult> EditPost(int id)
        {
            var client = this._dbContext.Shows.FirstOrDefault(c => c.ID == id);
            var ok = await this.TryUpdateModelAsync(client);

            if (ok && this.ModelState.IsValid)
            {
                this._dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {

            var show = this._dbContext.Shows.FirstOrDefault(c => c.ID == id);
            if (show != null)
            {
                var currentUser = this._userManager.GetUserId(base.User);
                var ratings = _dbContext.Ratings.Include(m => m.Show).Where(p => p.ShowID == show.ID).ToList();
                this._dbContext.Ratings.RemoveRange(ratings);
                this._dbContext.Shows.Remove(show);
            }
            this._dbContext.SaveChanges();

            return View("Index", this._dbContext.Shows.Include(c => c.ShowGenres).ThenInclude(cs => cs.Genre).Include(r => r.UserRatings).ToList());
        }

        [HttpPost]
        [Authorize]
        public IActionResult Rate(Rating model)
        {
            model.UserID = this._userManager.GetUserId(base.User);

            var show = _dbContext.Shows.Include(c => c.ShowGenres).ThenInclude(cs => cs.Genre)
                .Include(c => c.ShowWriters).ThenInclude(cs => cs.Writer).Include(c => c.ShowCharacters).ThenInclude(cs => cs.Character)
                .Include(c => c.ShowActors).ThenInclude(cs => cs.Actor).ThenInclude(c => c.CharacterActors).ThenInclude(c => c.Character)
                .Include(c => c.ShowStudios).ThenInclude(cs => cs.Studio).Include(r => r.UserRatings).Where(p => p.ID == model.ShowID).FirstOrDefault();

            var ratings = _dbContext.Ratings.Include(m => m.Movie).Include(u => u.User).ToList();
            var currentUser = this._userManager.GetUserId(base.User);
            foreach (var rating in ratings)
            {
                foreach (var modelMovie in show.UserRatings)
                {
                    if (modelMovie.ShowID == rating.ShowID && currentUser == rating.UserID)
                    {
                        this._dbContext.Remove(rating);
                    }
                }
            }

            this._dbContext.Add(model);
            this._dbContext.SaveChanges();

            ViewBag.Rating = model.Score;


            return View("Details", show);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> UploadPicture(IFormFile file, int movieId)
        {
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "shows");
            if (file.Length > 0)
            {
                var filePath = Path.Combine(uploads, file.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                var movie = this._dbContext.Movies.FirstOrDefault(c => c.ID == movieId);
                movie.PictureURL = file.FileName;
                var ok = await this.TryUpdateModelAsync(movie);

                if (ok && this.ModelState.IsValid)
                {
                    this._dbContext.SaveChanges();

                }


            }
            this._dbContext.SaveChanges();
            return Json(new { success = true });
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> UploadBackground(IFormFile file, int movieId)
        {
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "shows");
            if (file.Length > 0)
            {
                var filePath = Path.Combine(uploads, file.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                var movie = this._dbContext.Movies.FirstOrDefault(c => c.ID == movieId);
                movie.BackgroundURL = file.FileName;
                var ok = await this.TryUpdateModelAsync(movie);

                if (ok && this.ModelState.IsValid)
                {
                    this._dbContext.SaveChanges();

                }


            }
            this._dbContext.SaveChanges();
            return Json(new { success = true });
        }

    }
}