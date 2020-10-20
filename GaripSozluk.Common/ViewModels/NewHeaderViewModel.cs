
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Common.ViewModels
{
   public class NewHeaderViewModel: PageViewModel
    {
        public int CategoryId { get; set; }
        public String Title { get; set; }
        public List<SelectListItem> CategoryList { get; set; }

    }
}
