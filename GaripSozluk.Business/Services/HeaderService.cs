﻿using GaripSozluk.Business.Interfaces;
using GaripSozluk.Common.ViewModels;
using GaripSozluk.Data.Domain;
using GaripSozluk.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace GaripSozluk.Business.Services
{
   public class HeaderService:IHeaderService
    {
        private readonly IHeaderRepository _headerRepository;
        public HeaderService(IHeaderRepository headerRepository)
        {
            _headerRepository = headerRepository;
        }
        public ICollection<HeaderViewModel> GetAllCategory(int id)
        {
            List<HeaderViewModel> List = new List<HeaderViewModel>();
            foreach (var item in _headerRepository.GetAll(id).Include("Posts"))
            {
                var row = new HeaderViewModel();

                row.Title = item.Title;
                row.Id = item.Id;
                row.PostCount = item.Posts.Count;

                List.Add(row);

            }
            return List;
            
        }
        public int AddHeader(string headerName,ClaimsPrincipal contextUser,int categoryId)
        {           
            var userId = contextUser.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var header = new Header();
            header.UserId = userId;
            header.Title = headerName;
            header.CreateDate = DateTime.Now;
            header.CategoryId = categoryId;
            _headerRepository.Add(header);
            _headerRepository.SaveChanges();
            return header.Id;
        }
    }
}