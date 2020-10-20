using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Data.Domain
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }

        public List<Post> Posts { get; set; }
    }
}
