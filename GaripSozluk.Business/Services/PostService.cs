using GaripSozluk.Business.Interfaces;
using GaripSozluk.Common.ViewModels;
using GaripSozluk.Data.Domain;
using GaripSozluk.Data.Interfaces;
using System;
using System.Linq;

using System.Reflection;

using System.Linq.Expressions;
using System.Collections.Generic;

namespace GaripSozluk.Business.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public ICollection<PostViewModel> GetAllCategory(int id)
        {
            throw new NotImplementedException();
        }

        public PostViewModel GetAllPostByHeaderId(int id)
        {
            throw new NotImplementedException();
        }
        public int AddPost(NewPostViewModel model, int userId)
        {
            //var userId = contextUser.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;

            var post = new Post();
            post.UserId = userId;
            post.Content = model.Content;
            post.CreateDate = DateTime.Now;
            post.HeaderId = model.HeaderId;
            _postRepository.Add(post);

            try
            {
                _postRepository.SaveChanges();
                return post.Id;
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;
                throw;
            }

        }

       
    }

}
