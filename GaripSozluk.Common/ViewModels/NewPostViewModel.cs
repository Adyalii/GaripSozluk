
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GaripSozluk.Common.ViewModels
{
    public class NewPostViewModel : PageViewModel
    {
        //[HiddenInput]
        public int HeaderId { get; set; }
        public int CategoryId { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(2000)]
        public String Content { get; set; }
        
    }
}
