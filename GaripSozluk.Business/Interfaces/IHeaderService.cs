using GaripSozluk.Common.ViewModels;
using GaripSozluk.Data.Domain;
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
        int AddHeader(NewHeaderViewModel model,int userId);
        HeaderViewModel GetAllPostByHeaderId(int id, int currentPage = 1);
        int GetRandomHeaderId();
       List<HeaderViewModel> SearchHeaders(string searchText);
        List<HeaderViewModel> DetailedSearchHeaders(DetailedSearchViewModel model);
        void AddHeaderFromApi(string[] items);

        List<Header> GetAll(); 
    }
}
