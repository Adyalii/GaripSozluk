using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GaripSozluk.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GaripSozluk.WebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _headerCategoryService;
        public CategoryController(ICategoryService headerCategoryService)
        {
            _headerCategoryService = headerCategoryService;
        }
        public IActionResult Index()
        {
           
            //var x = _headerCategoryService.GetAll();
            return View();
        }

    }
}
