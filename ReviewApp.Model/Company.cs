using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReviewApp.Model
{
    public class Company
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string PictureURL { get; set; }
        public virtual ICollection<MovieStudio> MovieStudios { get; set; }
        public virtual ICollection<ShowStudio> ShowStudios { get; set; }
    }
}
