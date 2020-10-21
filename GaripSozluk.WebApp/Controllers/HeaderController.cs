using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult NewHeader(NewHeaderViewModel model)
        {
            if (model.Title !=null)
            {

                //_headerService.AddHeader(model.CategoryId);
                //_headerService.AddHeader(model.Title, HttpContext.User, model.CategoryId);
                //return Redirect(Url.Action("Index", "Home", new { categoryId = model.CategoryId }));
            }
            //ModelState.AddModelError("", "Boş alan bırakmayınız");
            return RedirectToAction("NewHeader", new { categoryId = model.CategoryId });
            
        }
    }
}
