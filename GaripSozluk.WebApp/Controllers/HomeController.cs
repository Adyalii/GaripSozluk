using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GaripSozluk.WebApp.Models;
using GaripSozluk.Business.Interfaces;

using GaripSozluk.Common.ViewModels;
using Microsoft.AspNetCore.Authorization;

using GaripSozluk.Data.Interfaces;


namespace GaripSozluk.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostService _postService;
        private readonly ICategoryService _headerCategoryService;
        private readonly IHeaderService _headerService;
        private readonly IWebApiService _webApiService;

        public HomeController(ILogger<HomeController> logger, IPostService postService, ICategoryService headerCategory, IHeaderService headerService, IWebApiService webApiService)
        {
            _logger = logger;
            _postService = postService;
            _headerCategoryService = headerCategory;
            _headerService = headerService;
            _webApiService = webApiService;
        }

        public IActionResult Index(int categoryId = 1, int headerId = 1, int currentPage = 1)
        {
            var model = new IndexViewModel();
            model.SelectedCategoryId = categoryId;
            model.Categories = _headerCategoryService.GetAllCategory();
            model.Headers = _headerService.GetAllCategory(categoryId);
            //var resultCount = _postService.GetAll().Count();      
            model.Header = _headerService.GetAllPostByHeaderId(headerId, currentPage);
            var headerList = _headerService.GetAll();
            if (categoryId == 7 || categoryId == 8)
            {
                model.Headers = _headerService.GetAllCategory(categoryId);
                var selectedHeader = _webApiService.SearchFromApiInHeader(model.Header.Title);
                var headerVM = new HeaderViewModel();
                var postLists = new List<PostViewModel>();
                foreach (var item in selectedHeader.docs)
                {
                    if (!headerList.Select(x => x.Title).Contains(item.title))
                    {
                        var postVM = new PostViewModel();
                        postVM.Content = item.title;
                        postVM.CreateDate = DateTime.Now;
                        postVM.publishYear = item.first_publish_year.ToString();
                        postVM.DisLikeCount = 0;
                        postVM.IsDisLiked = false;
                        postVM.IsLiked = false;
                        postVM.LikeCount = 0;
                        postVM.UserName = item.author_name?.FirstOrDefault().ToString();
                        postVM.UserId = 0;
                        postVM.Id = 0;
                        postLists.Add(postVM);
                    }
                }
                model.Header.PostLists = postLists;

                return View(model);
            }
            else
            {
                return View(model);
            }

        }



        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
