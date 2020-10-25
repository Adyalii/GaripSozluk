using GaripSozluk.Common.ViewModels;
using GaripSozluk.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GaripSozluk.Business.Interfaces
{
    public interface IPostService
    {
        ICollection<PostViewModel> GetAllCategory(int id);
        PostViewModel GetAllPostByHeaderId(int id);
        int AddPost(NewPostViewModel model, int userId);
    }
}

