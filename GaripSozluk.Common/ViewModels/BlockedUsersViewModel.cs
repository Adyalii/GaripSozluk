using GaripSozluk.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Common.ViewModels
{
   public class BlockedUsersViewModel:PageViewModel
    {
       
        public List<KeyValuePair<int,string>> BannedUserList { get; set; }
        
    }
}
