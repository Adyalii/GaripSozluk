
using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Common.ViewModels
{
   public class PageViewModel
    {
        //kategori listesi,sol tarafta aktif kategori başlık ve view model olacak,indexdeki modeli ver,viewmodeli göster
        public ICollection<CategoryViewModel> Categories { get; set; }
        public ICollection<HeaderViewModel> Headers { get; set; }
        public int SelectedCategoryId { get; set; }

    }
}
