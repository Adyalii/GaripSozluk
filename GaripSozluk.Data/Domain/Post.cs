using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Data.Domain
{
    public class Post : BaseEntity
    {

        public int HeaderId { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }



        public virtual Header Header { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<PostRating> Ratings { get; set; }

    }
}
