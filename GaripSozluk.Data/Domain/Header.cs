using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Data.Domain
{
    public class Header : BaseEntity  //+++
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public int ClickCount { get; set; }
        public string UserId { get; set; }

        public virtual HeaderCategory Category { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
