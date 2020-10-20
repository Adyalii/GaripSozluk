using GaripSozluk.Business.Interfaces;
using GaripSozluk.Common.ViewModels;
using GaripSozluk.Data.Domain;
using GaripSozluk.Data.Interfaces;
using GaripSozluk.Data.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GaripSozluk.Business.Services
{
   public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _headerCategoryRepository;
        public CategoryService(ICategoryRepository headerCategoryRepository)
        {
            _headerCategoryRepository = headerCategoryRepository;

        }

        public ICollection<CategoryViewModel> GetAllCategory()
        {
            List<CategoryViewModel> List = new List<CategoryViewModel>();
            foreach (var item in _headerCategoryRepository.GetAll())
            {
                var row = new CategoryViewModel();

                row.Title = item.Title;
                row.Id = item.Id;

                List.Add(row);

            }
            return List;
        }

        public List<SelectListItem> GetCategoryList()
        {
            var list = new List<SelectListItem>();

            foreach (var item in _headerCategoryRepository.GetAll())
            {
                var category = new SelectListItem();
                category.Text = item.Title;
                category.Value = item.Id.ToString();
                list.Add(category);
            }

            return list;
        }
        //public IQueryable<HeaderCategory> GetAll()
        //{
        //    return _headerCategoryRepository.GetAll();
        //}
    }
}
