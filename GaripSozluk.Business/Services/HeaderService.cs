using GaripSozluk.Business.Interfaces;
using GaripSozluk.Common.ViewModels;
using GaripSozluk.Data.Domain;
using GaripSozluk.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace GaripSozluk.Business.Services
{
    public class HeaderService : IHeaderService
    {
        private readonly IHeaderRepository _headerRepository;
        private readonly IPostRepository _postRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAccountService _accountService;
        private readonly IPostRatingService _postRatingService;
        public HeaderService(IHeaderRepository headerRepository, IPostRepository postRepository, IHttpContextAccessor httpContextAccessor, IAccountService accountService, IPostRatingService postRatingService)
        {

            _headerRepository = headerRepository;
            _postRepository = postRepository;
            _httpContextAccessor = httpContextAccessor;
            _accountService = accountService;
            _postRatingService = postRatingService;

        }
        public ICollection<HeaderViewModel> GetAllCategory(int id)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var headers = _headerRepository.GetAll().Where(x => x.CategoryId == id).Include("Posts");
            List<int> blockedIdList = new List<int>();
            if (user.Claims.Count() > 0)
            {
                var userId = int.Parse(user.Claims.ToList().First(x => x.Type == ClaimTypes.NameIdentifier).Value);
                var blockedUsers = _accountService.GetAll(userId);
                foreach (var item in blockedUsers)
                {
                    blockedIdList.Add(item.BannedUserId);
                }
            }


            List<HeaderViewModel> List = new List<HeaderViewModel>();
            foreach (var item in headers)
            {
                var row = new HeaderViewModel();

                row.Title = item.Title;
                row.Id = item.Id;
                row.PostCount = item.Posts.Where(x=>!blockedIdList.Contains(x.UserId)).Count();
                
                List.Add(row);
            }
            return List;

        }
        //public int AddHeader(string headerName, ClaimsPrincipal contextUser, int categoryId)
        //{
        public int AddHeader(NewHeaderViewModel model, int userId)
        {
            //var userId = contextUser.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;

            var header = new Header();
            header.UserId = userId;
            header.Title = model.Title;
            header.CreateDate = DateTime.Now;
            header.CategoryId = model.CategoryId;
            _headerRepository.Add(header);

            try
            {
                _headerRepository.SaveChanges();
                return header.Id;
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;
                throw;
            }

        }

        public HeaderViewModel GetAllPostByHeaderId(int id,int currentPage = 1)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var header = _headerRepository.GetAll().Where(x => x.Id == id).Include("Posts").FirstOrDefault();
            List<int> blockedIdList = new List<int>();

            int userId=0;
            if (user.Claims.Count()>0) 
            {
                 userId = int.Parse(user.Claims.ToList().First(x => x.Type == ClaimTypes.NameIdentifier).Value);
                var blockedUsers = _accountService.GetAll(userId);
                foreach (var item in blockedUsers)
                {
                    blockedIdList.Add(item.BannedUserId);

                }
            }
           

            HeaderViewModel model = new HeaderViewModel();
            if (header == null)
            {
                return model;
            }
            header.ClickCount++;
            model.ClickCount = header.ClickCount;
            model.Id = header.Id;
            //model.PostCount = header.Posts.Count;
            model.Title = header.Title;
            model.PostLists = new List<PostViewModel>();
          
            var itemCount = _postRepository.GetAll().Where(x => x.HeaderId == header.Id).Include("User").Where(x => !blockedIdList.Contains(x.UserId)).Count();//yorumları sayıyoruz(Engellenmiş hali ile)
            model.currentPage = currentPage;
            var itemSize = 5;
            var pageCount = itemCount / itemSize + (itemCount % itemSize > 0 ? 1 : 0);
            model.previousPage = currentPage - 1 > 0 ? currentPage - 1 : pageCount;
            model.nextPage = currentPage + 1 <= pageCount ? currentPage + 1 : 1;
            model.pageCount = pageCount;

            var headerPost = _postRepository.GetAll().Where(x => x.HeaderId == header.Id).Include("User").Where(x => !blockedIdList.Contains(x.UserId))//Yorumları alıyoruz(Engellenmiş hali ile)
            .Skip((currentPage - 1) * itemSize).Take(itemSize).ToList();//Yorumları sayfalıyoruz

            if (headerPost != null)
            {
                foreach (var item in headerPost)
                {
                    var row = new PostViewModel();

                    row.Content = item.Content;
                    row.UserId = item.UserId;
                    row.UserName = item.User.UserName;
                    row.Id = item.Id;
                    row.CreateDate = item.CreateDate;
                    row.LikeCount = _postRatingService.CountLike(row.Id);
                    row.DisLikeCount = _postRatingService.CountDisLike(row.Id);

                    if (userId > 0)
                    {
                        row.IsLiked = _postRatingService.IsLiked(item.Id, userId);
                        row.IsDisLiked = _postRatingService.IsDisLiked(item.Id, userId);
                    }
                    
                    model.PostLists.Add(row);
                }

                model.PostCount = model.PostLists.Count;
            }
            _headerRepository.SaveChanges();
            return model;
        }

        public int GetRandomHeaderId()
        {
            var idList = _headerRepository.GetAll().Select(x => x.Id).ToList();
            var randomNumber = new Random().Next(idList.Count - 1);
            var randomId = idList[randomNumber];
            return randomId;
        }

        public List<HeaderViewModel> SearchHeaders(string searchText)
        {
            var model = new List<HeaderViewModel>();
            var headers = _headerRepository.GetAll().Where(x => x.Title.Contains(searchText)).ToList();
            foreach (var item in headers)
            {
                var header = new HeaderViewModel();
                header.ClickCount = item.ClickCount;
                header.Id = item.Id;
                header.Title = item.Title;
                model.Add(header);

            }

            return model;
        }
        public List<HeaderViewModel> DetailedSearchHeaders(DetailedSearchViewModel model)
        {

            var query = _headerRepository.GetAll().Where(x => true);


            if (model.CategoryId != null)
            {
                query = query.Where(x => x.CategoryId == model.CategoryId);
            }


            if (model.Text != null)
            {
                query = query.Where(x => x.Title.Contains(model.Text));
            }

            if (model.DateOne.HasValue || model.DateTwo.HasValue)
            {
                if (model.DateOne.HasValue && model.DateTwo == null)
                {
                    query = query.Where(x => x.CreateDate > model.DateOne.Value);
                }
                else if (model.DateOne == null && model.DateTwo.HasValue)
                {
                    query = query.Where(x => x.CreateDate < model.DateTwo.Value);
                }
                else
                {
                    query = query.Where(x => (x.CreateDate >= model.DateOne.Value && x.CreateDate <= model.DateTwo.Value));
                }

            }

            if (model.SortType == 1)
            {
                query = query.OrderByDescending(x => x.CreateDate);
                model.FoundedDetailedHeaders = new List<HeaderViewModel>();
                foreach (var item in query.ToList())
                {
                    var header = new HeaderViewModel();
                    header.ClickCount = item.ClickCount;
                    header.Id = item.Id;
                    header.Title = item.Title;
                    model.FoundedDetailedHeaders.Add(header);

                }
            }

            if (model.SortType == 2)
            {
                query = query.OrderBy(x => x.CreateDate);
                model.FoundedDetailedHeaders = new List<HeaderViewModel>();
                foreach (var item in query.ToList())
                {
                    var header = new HeaderViewModel();
                    header.ClickCount = item.ClickCount;
                    header.Id = item.Id;
                    header.Title = item.Title;
                    model.FoundedDetailedHeaders.Add(header);

                }
            }
            return model.FoundedDetailedHeaders;

        }
    }
}
