﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Data.Domain
{
   public class IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}


