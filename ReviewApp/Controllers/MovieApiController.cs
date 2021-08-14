using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.DAL;
using ReviewApp.Model;

namespace ReviewApp.Web.Controllers
{
    [Route("api/movie")]
    [ApiController]
    public class MovieApiController : Controller
    {

        private ApplicationDbContext _dbContext;
        public MovieApiController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public IActionResult Get()
        {
            var movies = this._dbContext.Movies.Select(c => new MovieDTO()
            {
                ID = c.ID,
                Title = c.Title,
                Synopsis = c.Synopsis,
                ReleaseDate = c.ReleaseDate,
                CountryOfRelease = c.CountryOfRelease,
                Director = this._dbContext.People.Where(p => p.ID == c.Director.ID).Select(p => new PersonDTO()
                {
                    ID = p.ID,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    PlaceOfBirth = p.PlaceOfBirth,
                    DateOfBirth = p.DateOfBirth,
                    Gender = p.Gender,
                    CountryOfBirth = p.CountryOfBirth
                }).FirstOrDefault(),
                
            }).ToList();
            return Ok(movies);
        }

        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var movie = this._dbContext.Movies.Where(m => m.ID == id).Select(c => new MovieDTO()
            {
                ID = c.ID,
                Title = c.Title,
                Synopsis = c.Synopsis,
                ReleaseDate = c.ReleaseDate,
                CountryOfRelease = c.CountryOfRelease,
                Director = this._dbContext.People.Where(p => p.ID == c.Director.ID).Select(p => new PersonDTO()
                {
                    ID = p.ID,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    PlaceOfBirth = p.PlaceOfBirth,
                    DateOfBirth = p.DateOfBirth,
                    Gender = p.Gender,
                    CountryOfBirth = p.CountryOfBirth
                }).FirstOrDefault()
            }).FirstOrDefault();

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpPost]
        public IActionResult Post([FromBody] MovieDTO movie)
        {
                this._dbContext.Movies.Add(new Movie()
                {
                    Title = movie.Title,
                    Synopsis = movie.Synopsis,
                    ReleaseDate = movie.ReleaseDate,
                    CountryOfRelease = movie.CountryOfRelease,
                    Director = this._dbContext.People.Where(p => p.ID == movie.Director.ID).FirstOrDefault()
                });

            this._dbContext.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody] MovieDTO movie)
        {
            var movieDb = this._dbContext.Movies.First(c => c.ID == id);
            if (movie.Title != null)
            {
                movieDb.Title = movie.Title;
            }
            if (movie.ReleaseDate != null)
            {
                movieDb.ReleaseDate = movie.ReleaseDate;
            }
            if (movie.CountryOfRelease != null)
            {
                movieDb.CountryOfRelease = movie.CountryOfRelease;
            }
            if (movie.Synopsis != null)
            {
                movieDb.Synopsis = movie.Synopsis;
            }
            if (movie.Director != null)
            {
                movieDb.Director = this._dbContext.People.Where(p => p.ID == movie.Director.ID).FirstOrDefault();
            }
            this._dbContext.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var movieDb = this._dbContext.Movies.First(c => c.ID == id);
            this._dbContext.Remove(movieDb);
            this._dbContext.SaveChanges();
            return Ok();
        }


    }
    public class MovieDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CountryOfRelease { get; set; }
        public string Synopsis { get; set; }
        public PersonDTO Director { get; set; }
    }

    public class PersonDTO
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
        public string PlaceOfBirth { get; set; }
        public string CountryOfBirth { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }

}