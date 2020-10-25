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

        public HomeController(ILogger<HomeController> logger, IPostService postService, ICategoryService headerCategory,IHeaderService headerService)
        {
            _logger = logger;
            _postService = postService;
            _headerCategoryService = headerCategory;
            _headerService = headerService;
        }

        public IActionResult Index(int categoryId=1,int headerId=1,int currentPage=1)
        {
            var model = new IndexViewModel();
            model.SelectedCategoryId = categoryId;
            model.Categories = _headerCategoryService.GetAllCategory();
            model.Headers = _headerService.GetAllCategory(categoryId);
            //var resultCount = _postService.GetAll().Count();      
            model.Header = _headerService.GetAllPostByHeaderId(headerId,currentPage);
            return View(model);
        }


        
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
