using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Common.ViewModels
{
   public class ApiSearchViewModel:PageViewModel
    {
        public string Text { get; set; }
        public int SearchType { get; set; }
        public List<Doc> docs { get; set; }

    }
}
