using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace GaripSozluk.Common.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }


        [Display(Name = "Başlık")]
        [Required(ErrorMessage = "Başlık boş bırakılamaz")]
        public string Title { get; set; }
    }
}
