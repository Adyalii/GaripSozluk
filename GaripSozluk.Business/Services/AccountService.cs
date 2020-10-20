﻿using GaripSozluk.Business.Interfaces;
using GaripSozluk.Common.ViewModels;
using GaripSozluk.Data.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GaripSozluk.Business.Services
{
    public class AccountService : IAccountService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        public AccountService(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;

        }

        //public async Task<UserClaimViewModel> GetUserInfos()
        //{
        //    var user = _httpContextAccessor.HttpContext.User;
        //    var dbUser = await _userManager.GetUserAsync(user);

        //    UserClaimViewModel userClaimViewModel = new UserClaimViewModel()
        //    {
        //        Email = dbUser.Email,
        //        FullName = dbUser.FullName,
        //        UserId = dbUser.Id
        //    };

        //    return userClaimViewModel;
        //}
    }
}
