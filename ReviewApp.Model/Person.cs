using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReviewApp.Model
{
    public class Person
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public char Gender { get; set; }
        public string Description { get; set; }
        public string PlaceOfBirth { get; set; }
        public string CountryOfBirth { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PictureURL { get; set; }

        public virtual ICollection<MovieActor> MovieActors { get; set; }
        public virtual ICollection<ShowActor> ShowActors { get; set; }
        public virtual ICollection<CharacterActor> CharacterActors { get; set; }

        public virtual ICollection<MovieWriter> MovieWriters { get; set; }
        public virtual ICollection<ShowWriter> ShowWriters { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
