using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Data.Domain
{
    public class HeaderCategory : BaseEntity 
    {
        public string Title { get; set; }



        public ICollection<Header> Headers { get; set; }
    }
}
