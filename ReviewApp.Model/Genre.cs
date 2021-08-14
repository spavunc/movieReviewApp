using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReviewApp.Model
{
    public class Genre
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string name { get; set; }
        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
        public virtual ICollection<ShowGenre> ShowGenres { get; set; }
    }
}
