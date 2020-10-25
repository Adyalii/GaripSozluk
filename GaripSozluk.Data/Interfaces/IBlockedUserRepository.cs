﻿using GaripSozluk.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GaripSozluk.Data.Interfaces
{
   public interface IBlockedUserRepository: IBaseRepository<BlockedUser>
    {
        IQueryable<BlockedUser> GetUsers(int id);
       
    }
}
