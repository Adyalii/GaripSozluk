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
    public class WebApiController : Controller
    {
        private readonly IWebApiService _webApiService;
        private readonly IHeaderService _headerService;

        public WebApiController(IWebApiService webApiService, IHeaderService headerService)
        {
            _webApiService = webApiService;
            _headerService = headerService;
        }

        [Authorize]
        public IActionResult ApiSearchForm()
        {         
            return View();
        }

        [Authorize]
        public IActionResult ApiSearchResult(ApiSearchViewModel model = null)
        {
            model = _webApiService.SearchFromApi(model);
            return View(model);
        }

        [HttpPost]
        public IActionResult AddHeaderFromApi(string[] items)
        {
            _headerService.AddHeaderFromApi(items);
            return Json(new { });
        }
    }
}
