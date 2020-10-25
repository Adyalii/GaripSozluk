using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Common.ViewModels
{
   public class HeaderViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PostCount { get; set; }
        public int ClickCount { get; set; }
        public List<PostViewModel> PostLists { get; set; }

        public int pageCount { get; set; }
        public int currentPage { get; set; }
        public int previousPage { get; set; }
        public int nextPage { get; set; }

    }
}
