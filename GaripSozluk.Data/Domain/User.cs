using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Data.Domain
{

    public class User : IdentityUser
    {
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? BirthDate { get; set; }



        public virtual ICollection<Header> Headers { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<PostRating> Ratings { get; set; }
        public virtual ICollection<BannedUser> BlockedUsers { get; set; }


    }
}
