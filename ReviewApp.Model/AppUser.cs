using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ReviewApp.Model
{
    public class AppUser : IdentityUser
    {
        public virtual ICollection<Rating> UserRatings { get; set; }
    }

    public class Rating
    {
        public int ID { get; set; }
        public int Score { get; set; }
        public AppUser User { get; set; }
        [ForeignKey(nameof(User))]
        public string UserID { get; set; }
        public virtual Movie Movie { get; set; }
        [ForeignKey(nameof(Movie))]
        public int? MovieID { get; set; }
        public virtual Show Show { get; set; }
        [ForeignKey(nameof(Show))]
        public int? ShowID { get; set; }
    }

}
