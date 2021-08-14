using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ReviewApp.Model
{
    public class Movie
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Title is too long!")]
        public string Title { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public string CountryOfRelease { get; set; }
        public float AverageScore;
        public string PictureURL { get; set; }
        public string TrailerURL { get; set; }
        public string BackgroundURL { get; set; }
        [Required]
        public string Synopsis { get; set; }
        [Range(1, 1000)]
        public int DurationMinutes { get; set; }
        public Person Director { get; set; }
        [ForeignKey(nameof(Director))]
        public int? DirectorID { get; set; }
        public virtual ICollection<MovieWriter> MovieWriters { get; set; }
        public virtual ICollection<MovieActor> MovieActors { get; set; }
        public virtual ICollection<MovieStudio> MovieStudios { get; set; }
        public virtual ICollection<MovieCharacter> MovieCharacters { get; set; }
        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
        public virtual ICollection<Rating> UserRatings { get; set; }

    }

    public class MovieWriter
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int WriterId { get; set; }
        public Person Writer { get; set; }
    }
    public class MovieActor
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int ActorId { get; set; }
        public Person Actor { get; set; }
    }
    public class MovieStudio
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int StudioId { get; set; }
        public Company Studio { get; set; }
    }
    public class MovieGenre
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
