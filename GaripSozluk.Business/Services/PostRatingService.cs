using GaripSozluk.Business.Interfaces;
using GaripSozluk.Data.Domain;
using GaripSozluk.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GaripSozluk.Business.Services
{
   public class PostRatingService:IPostRatingService
    {

        private readonly IPostRatingRepository _postRatingRepository;
        public PostRatingService(IPostRatingRepository postRatingRepository)
        {
            _postRatingRepository = postRatingRepository;
        }
        public void AddLike(int postId,int userId)
        {
            var getLike = _postRatingRepository.Get(x => x.UserId == userId && x.PostId == postId);
            if (getLike != null)
            {
                if (getLike.IsLiked == true)
                {
                    _postRatingRepository.Remove(getLike);
                }
                else
                {
                    getLike.IsLiked = true;
                    getLike.UpdateDate = DateTime.Now;
                    _postRatingRepository.SaveChanges();
                }
                return;
            }
            
            var post = new PostRating();
            post.PostId = postId;
            post.UserId = userId;
            post.IsLiked = true;
            post.CreateDate = DateTime.Now;
            var entity = _postRatingRepository.Add(post);
            try
            {
                _postRatingRepository.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void DisLike(int postId, int userId)
        {
            var getLike = _postRatingRepository.Get(x => x.UserId == userId && x.PostId == postId);
            if (getLike != null)
            {
                if (getLike.IsLiked == false)
                {
                    _postRatingRepository.Remove(getLike);
                }
                else
                {
                    getLike.IsLiked = false;
                    getLike.UpdateDate = DateTime.Now;
                    _postRatingRepository.SaveChanges();
                }
                return;
            }

            var post = new PostRating();
            post.PostId = postId;
            post.UserId = userId;
            post.IsLiked = false;
            post.CreateDate = DateTime.Now;
            var entity = _postRatingRepository.Add(post);
            try
            {
                _postRatingRepository.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int CountLike(int postId)
        {
         return _postRatingRepository.GetAll(x => x.PostId == postId && x.IsLiked == true).Count();
        }

        public int CountDisLike(int postId)
        {
            return _postRatingRepository.GetAll(x => x.PostId == postId && x.IsLiked == false).Count();
        }

        public bool IsLiked(int postId,int userId)
        {
            return _postRatingRepository.GetAll(x => x.PostId == postId && x.IsLiked == true && x.UserId== userId).Any();
        }

        public bool IsDisLiked(int postId, int userId)
        {
            return _postRatingRepository.GetAll(x => x.PostId == postId && x.IsLiked == false && x.UserId == userId).Any();
        }
    }
}
