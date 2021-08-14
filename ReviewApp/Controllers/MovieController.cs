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
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using ReviewApp.Web.Models;

namespace ReviewApp.Web.Controllers
{
    public class MovieController : Controller
    {

        private ApplicationDbContext _dbContext;
        private UserManager<AppUser> _userManager;
        private IHostingEnvironment _hostingEnvironment;

        public MovieController(ApplicationDbContext dbContext, UserManager<AppUser> userManager, IHostingEnvironment environment)
        {
            this._dbContext = dbContext;
            this._userManager = userManager;
            this._hostingEnvironment = environment;
        }
        [Route("Movies")]
        public IActionResult Index()
        {
            var movies = _dbContext.Movies.Include(p => p.Director).Include(c => c.MovieGenres).ThenInclude(cs => cs.Genre)
                .Include(c => c.MovieWriters).ThenInclude(cs => cs.Writer).Include(c => c.MovieCharacters).ThenInclude(cs => cs.Character)
                .Include(c => c.MovieActors).ThenInclude(cs => cs.Actor).ThenInclude(c => c.CharacterActors).ThenInclude(c => c.Character)
                .Include(c => c.MovieStudios).ThenInclude(cs => cs.Studio).Include(r => r.UserRatings).ToList();


            return View(movies);
        }

        [HttpPost]
        public ActionResult IndexAjax(MovieFilterModel filter)
        {
            var movieQuery = _dbContext.Movies.Include(p => p.Director).Include(c => c.MovieGenres).ThenInclude(cs => cs.Genre)
                .Include(c => c.MovieWriters).ThenInclude(cs => cs.Writer).Include(c => c.MovieCharacters).ThenInclude(cs => cs.Character)
                .Include(c => c.MovieActors).ThenInclude(cs => cs.Actor).ThenInclude(c => c.CharacterActors).ThenInclude(c => c.Character)
                .Include(c => c.MovieStudios).ThenInclude(cs => cs.Studio).Include(r => r.UserRatings).AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Name))
                movieQuery = movieQuery.Where(p => (p.Title).Contains(filter.Name));

             var model = movieQuery.ToList();
            return PartialView("_IndexTable", model);
        }

        public IActionResult Details(int? id= null)
        {
            var movie =  _dbContext.Movies.Include(p => p.Director).Include(c => c.MovieGenres).ThenInclude(cs => cs.Genre)
                .Include(c => c.MovieWriters).ThenInclude(cs => cs.Writer).Include(c => c.MovieCharacters).ThenInclude(cs => cs.Character)
                .Include(c => c.MovieActors).ThenInclude(cs => cs.Actor).ThenInclude(c => c.CharacterActors).ThenInclude(c => c.Character)
                .Include(c=> c.MovieStudios).ThenInclude(cs => cs.Studio).Include(r => r.UserRatings).Where(p => p.ID == id).FirstOrDefault();

            var ratings = _dbContext.Ratings.Include(m => m.Movie).Include(u => u.User).ToList();
            var currentUser = this._userManager.GetUserId(base.User);
            foreach (var rating in ratings)
            {
                foreach (var model in movie.UserRatings) {
                    if (model.MovieID == rating.MovieID && currentUser == rating.UserID)
                    {
                        ViewBag.Rating = rating.Score;
                        return View(movie);
                    }
                }
            }

            return View(movie);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            this.FillDropdownValues();
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(Movie model)
        {
            if (ModelState.IsValid)
            {
                this._dbContext.Add(model);
                this._dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            this.FillDropdownValues();
            return View();
        }
        [Authorize(Roles = "Admin")]
        [ActionName(nameof(Edit))]
        public IActionResult Edit(int id)
        {
            var model = this._dbContext.Movies.FirstOrDefault(c => c.ID == id);
            this.FillDropdownValues();
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ActionName(nameof(Edit))]
        public async Task<IActionResult> EditPost(int id)
        {
            var client = this._dbContext.Movies.FirstOrDefault(c => c.ID == id);
            var ok = await this.TryUpdateModelAsync(client);

            if (ok && this.ModelState.IsValid)
            {
                this._dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            this.FillDropdownValues();
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {

            var movie = this._dbContext.Movies.FirstOrDefault(c => c.ID == id);
            if (movie != null)
            {
                var currentUser = this._userManager.GetUserId(base.User);
                var ratings = _dbContext.Ratings.Include(m => m.Movie).Where(p => p.MovieID == movie.ID).ToList();
                this._dbContext.Ratings.RemoveRange(ratings);

                this._dbContext.Movies.Remove(movie);
            }
            this._dbContext.SaveChanges();

            return View("_IndexTable", this._dbContext.Movies.Include(p => p.Director).Include(c => c.MovieGenres).ThenInclude(cs => cs.Genre).Include(r => r.UserRatings).AsQueryable());
        }

        [HttpPost]
        [Authorize]
        public IActionResult Rate(Rating model)
        {
            model.UserID = this._userManager.GetUserId(base.User);

            var movie = _dbContext.Movies.Include(p => p.Director).Include(c => c.MovieGenres).ThenInclude(cs => cs.Genre)
                .Include(c => c.MovieWriters).ThenInclude(cs => cs.Writer).Include(c => c.MovieCharacters).ThenInclude(cs => cs.Character)
                .Include(c => c.MovieActors).ThenInclude(cs => cs.Actor).ThenInclude(c => c.CharacterActors).ThenInclude(c => c.Character)
                .Include(c => c.MovieStudios).ThenInclude(cs => cs.Studio).Include(r => r.UserRatings).Where(p => p.ID == model.MovieID).FirstOrDefault();

            var ratings = _dbContext.Ratings.Include(m => m.Movie).Include(u => u.User).ToList();
            var currentUser = this._userManager.GetUserId(base.User);
            foreach (var rating in ratings)
            {
                foreach (var modelMovie in movie.UserRatings)
                {
                    if (modelMovie.MovieID == rating.MovieID && currentUser == rating.UserID)
                    {
                        this._dbContext.Remove(rating);
                    }
                }
            }

            this._dbContext.Add(model);
            this._dbContext.SaveChanges();
            ViewBag.Rating = model.Score;


            return View("Details", movie);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> UploadPicture(IFormFile file, int movieId)
        {
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "movies");
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
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "movies");
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

        private void FillDropdownValues()
        {
            var selectItems = new List<SelectListItem>();

            var listItem = new SelectListItem();
            listItem.Text = "- odaberite -";
            listItem.Value = "";
            selectItems.Add(listItem);

            foreach (var category in this._dbContext.People)
            {
                listItem = new SelectListItem(category.FullName, category.ID.ToString());
                selectItems.Add(listItem);
            }

            ViewBag.PossiblePeople = selectItems;
        }
    }
}