using GaripSozluk.Business.Interfaces;
using GaripSozluk.Common.ViewModels;
using GaripSozluk.Data.Domain;
using GaripSozluk.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GaripSozluk.Business.Services
{
    public class AccountService : IAccountService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        private readonly IBlockedUserRepository _blockedUserRepository;
        public AccountService(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, IBlockedUserRepository blockedUserRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _blockedUserRepository = blockedUserRepository;

        }
        public void AddBan(int userId, int BannedUserId)
        {
            if (userId !=BannedUserId)
            {
                var isBanned = _blockedUserRepository.Get(x => x.BannedUserId == BannedUserId && x.UserId == userId);
                if (isBanned != null)
                {
                    return;
                }
                var blockedUser = new BlockedUser();
                blockedUser.BannedUserId = BannedUserId;
                blockedUser.UserId = userId;
                blockedUser.CreateDate = DateTime.Now;


                _blockedUserRepository.Add(blockedUser);
                try
                {
                    _blockedUserRepository.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }          
        }
        public IQueryable<BlockedUser> GetAll(int id)
        {
            return _blockedUserRepository.GetUsers(id);
        }

        public void RemoveBan(int bannedId,int userId)
        {
            var blockedUser = _blockedUserRepository.Get(x => x.BannedUserId == bannedId && x.UserId==userId);
            if (blockedUser != null)
            {
                _blockedUserRepository.Remove(blockedUser);
            }
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
