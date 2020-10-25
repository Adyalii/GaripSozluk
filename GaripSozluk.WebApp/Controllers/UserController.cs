using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GaripSozluk.Business.Interfaces;
using GaripSozluk.Common.ViewModels;
using GaripSozluk.Data.Domain;
using GaripSozluk.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GaripSozluk.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IAccountService _accountService;
        public UserController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [Authorize]
        public IActionResult BanUser(int blockedUserId,int headerId, int categoryId)
        {
            var userId = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
            _accountService.AddBan(int.Parse(userId),blockedUserId);
            return Redirect(Url.Action("Index", "Home", new { headerId = headerId, categoryId = categoryId }));
        }

        
         public IActionResult GetBanUsers()
        {
           
            var userId = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var blockedUsers = _accountService.GetAll(int.Parse(userId)).Include("User").Include("BanUser");
            var model = new BlockedUsersViewModel();
            model.BannedUserList = new List<KeyValuePair<int, string>>();

            foreach (var item in blockedUsers)
            {
               
                model.BannedUserList.Add( new KeyValuePair<int, string>(item.BannedUserId,item.BanUser.UserName));

            }
            
            return View(model);
            
        }

        public IActionResult RemoveBan(int BanUserId)
        {
            var userId = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
            _accountService.RemoveBan(BanUserId, int.Parse(userId));
            return Redirect(Url.Action("GetBanUsers", "User" ));
        }
         
    }
}
