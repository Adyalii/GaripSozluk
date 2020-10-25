using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GaripSozluk.Business.Interfaces;
using GaripSozluk.Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GaripSozluk.WebApp.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRatingService _postRatingService;
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly ICategoryService _headerCategoryService;
        private readonly IHeaderService _headerService;
        public PostController(IPostService postService, ICategoryService categoryService, ICategoryService headerCategoryService, IHeaderService headerService, IPostRatingService postRatingService)
        {
            _postService = postService;
            _categoryService = categoryService;
            _headerCategoryService = headerCategoryService;
            _headerService = headerService;
            _postRatingService = postRatingService;
        }

        [Authorize]
        public IActionResult AddPost(int categoryId,int headerId)
        {
           
            var model = new NewPostViewModel();
           
            model.SelectedCategoryId = categoryId;
            model.Categories = _headerCategoryService.GetAllCategory();
            model.Headers = _headerService.GetAllCategory(categoryId);
            model.HeaderId = headerId;
            model.CategoryId = categoryId;
            return View(model);
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddPost(NewPostViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
                _postService.AddPost(model, int.Parse(userId));               
                return Redirect(Url.Action("Index", "Home", new { headerId = model.HeaderId, categoryId = model.CategoryId }));
            }
            ModelState.AddModelError("", "Boş alan bırakmayınız");
            model.SelectedCategoryId = model.CategoryId;
            model.Categories = _headerCategoryService.GetAllCategory();
            model.Headers = _headerService.GetAllCategory(model.CategoryId);
            //return RedirectToAction("AddPost", new { headerId = model.HeaderId ,categoryId= model.CategoryId});
            return View(model);

        }
        [Authorize]
        public IActionResult AddLike(int postId,int headerId,int categoryId)
        {
            var userId = int.Parse(HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
            _postRatingService.AddLike(postId, userId);

            return Redirect(Url.Action("Index", "Home", new { headerId = headerId, categoryId = categoryId }));
        }

        [Authorize]
        public IActionResult AddDislike(int postId, int headerId, int categoryId)
        {
            var userId = int.Parse(HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
            _postRatingService.DisLike(postId, userId);
            return Redirect(Url.Action("Index", "Home", new { headerId = headerId, categoryId = categoryId }));
        }
    }
}
