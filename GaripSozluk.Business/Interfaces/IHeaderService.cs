using GaripSozluk.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace GaripSozluk.Business.Interfaces
{
   public interface IHeaderService
    {
        ICollection<HeaderViewModel> GetAllCategory(int id);
        //int AddHeader(string headerName, ClaimsPrincipal contextUser, int categoryId);
        //int AddHeader();
    }
}
