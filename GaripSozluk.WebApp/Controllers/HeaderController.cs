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
    public class HeaderController : Controller
    {
        private readonly IHeaderService _headerService;
        private readonly ICategoryService _categoryService;
        public HeaderController(IHeaderService headerService,ICategoryService categoryService)
        {
            _headerService = headerService;
            _categoryService = categoryService;
        }
        [Authorize]
        public IActionResult NewHeader(int categoryId)
        {
            //_headerService.AddHeader("", HttpContext.User, 1);
            var model = new NewHeaderViewModel();
            model.SelectedCategoryId = categoryId;
            model.Categories = _categoryService.GetAllCategory();
            model.Headers = _headerService.GetAllCategory(categoryId);
            model.CategoryId = categoryId;
            model.CategoryList = _categoryService.GetCategoryList();
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult NewHeader(NewHeaderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
                _headerService.AddHeader(model,int.Parse(userId));
                //_headerService.AddHeader(model.Title, HttpContext.User, model.CategoryId);
                //return Redirect(Url.Action("Index", "Home", new { categoryId = model.CategoryId }));
            }
            //ModelState.AddModelError("", "Boş alan bırakmayınız");
            return RedirectToAction("NewHeader", new { categoryId = model.CategoryId });
            
        }

        public IActionResult GetRandomHeader(int categoryId)
        {
            var randomHeaderId = _headerService.GetRandomHeaderId();


            return Redirect(Url.Action("Index","Home", new { headerId = randomHeaderId , categoryId = categoryId }));
        }

        public IActionResult SearchHeader(int categoryId,string searchText)
        {
            var model = new SearchHeaderViewModel();
            model.SelectedCategoryId = categoryId;
            model.Categories = _categoryService.GetAllCategory();
            model.Headers = _headerService.GetAllCategory(categoryId);
            model.FoundedHeaders = _headerService.SearchHeaders(searchText);

            return View(model);
        }
        public IActionResult DetailedSearch(int categoryId)
        {

            var model = new DetailedSearchViewModel();
            model.SelectedCategoryId = categoryId;
            model.Categories = _categoryService.GetAllCategory();
            model.Headers = _headerService.GetAllCategory(categoryId);
            model.CategoryId = categoryId;
            model.CategoryList = _categoryService.GetCategoryList();
           

            return View(model);
        }
        [HttpPost]
        public IActionResult DetailedSearch(int categoryId,DetailedSearchViewModel model=null)
        {
           
            model.SelectedCategoryId = categoryId;
            model.Categories = _categoryService.GetAllCategory();
            model.Headers = _headerService.GetAllCategory(categoryId);
            model.FoundedDetailedHeaders = _headerService.DetailedSearchHeaders(model);
            model.CategoryList = _categoryService.GetCategoryList();

            return View(model);
        }
    }
}
