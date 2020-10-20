using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Data.Domain
{
    public class BannedUser : BaseEntity   //++
    {
        public string UserId { get; set; }
        public string BannedUserId { get; set; }


        public virtual User User { get; set; }
    }
}