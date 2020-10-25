using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Common.ViewModels
{
   public class DetailedSearchViewModel:PageViewModel
    {
        public string Text { get; set; }
        public DateTime? DateOne { get; set; }
        public DateTime? DateTwo { get; set; }
        public int SortType { get; set; }
        public int? CategoryId { get; set; }
        public List<HeaderViewModel> FoundedDetailedHeaders { get; set; }
        public List<SelectListItem> CategoryList { get; set; }
    }
}
