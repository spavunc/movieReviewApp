using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReviewApp.Model
{
    public class Character
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public char Gender { get; set; }
        public string Description { get; set; }
        public string PictureURL { get; set; }
        public virtual ICollection<MovieCharacter> MovieCharacters { get; set; }
        public virtual ICollection<ShowCharacter> ShowCharacters { get; set; }
        public virtual ICollection<CharacterActor> CharacterActors { get; set; }

        public string FullName => $"{FirstName} {LastName}";

    }

    public class MovieCharacter
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
    public class CharacterActor
    {
        public int CharacterId { get; set; }
        public Character Character { get; set; }
        public int ActorId { get; set; }
        public Person Actor { get; set; }
    }
    public class ShowCharacter
    {
        public int ShowId { get; set; }
        public Show Show { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
