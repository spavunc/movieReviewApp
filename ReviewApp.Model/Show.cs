using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReviewApp.Model
{
    public class Show
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Title is too long!")]
        public string Title { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        public float AverageScore;
        public string CountryOfRelease { get; set; }
        public string PictureURL { get; set; }
        public string TrailerURL { get; set; }
        [Range(1, 200)]
        public int EpisodeDuration { get; set; }
        public int NumberOfEpisodes { get; set; }
        public string BackgroundURL { get; set; }
        [Required]
        public string Synopsis { get; set; }
        public virtual ICollection<ShowWriter> ShowWriters { get; set; }
        public virtual ICollection<ShowActor> ShowActors { get; set; }
        public virtual ICollection<ShowStudio> ShowStudios { get; set; }
        public virtual ICollection<ShowCharacter> ShowCharacters { get; set; }
        public virtual ICollection<ShowGenre> ShowGenres { get; set; }
        public virtual ICollection<Rating> UserRatings { get; set; }
    }

    public class ShowWriter
    {
        public int ShowId { get; set; }
        public Show Show { get; set; }
        public int WriterId { get; set; }
        public Person Writer { get; set; }
    }
    public class ShowActor
    {
        public int ShowId { get; set; }
        public Show Show { get; set; }
        public int ActorId { get; set; }
        public Person Actor { get; set; }
    }
    public class ShowStudio
    {
        public int ShowId { get; set; }
        public Show Show { get; set; }
        public int StudioId { get; set; }
        public Company Studio { get; set; }
    }

    public class ShowGenre
    {
        public int ShowId { get; set; }
        public Show Show { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
