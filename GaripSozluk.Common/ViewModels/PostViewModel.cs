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
        public string Content { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public int LikeCount { get; set; }
        public int DisLikeCount { get; set; }
        public bool IsLiked { get; set; }
        public bool IsDisLiked { get; set; }
        public DateTime CreateDate { get; set; }
        public string publishYear { get; set; }
        public ICollection<PostViewModel> Posts { get; set; }

    }
}
