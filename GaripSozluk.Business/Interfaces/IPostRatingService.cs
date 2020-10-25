using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Business.Interfaces
{
    public interface IPostRatingService
    {
        void AddLike(int postId, int userId);
        void DisLike(int postId, int userId);
        int CountLike(int postId);
        int CountDisLike(int postId);

        bool IsLiked(int postId, int userId);

        bool IsDisLiked(int postId, int userId);
    }
}
