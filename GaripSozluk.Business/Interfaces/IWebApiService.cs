﻿using GaripSozluk.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Business.Interfaces
{
   public interface IWebApiService
    {
        ApiSearchViewModel SearchFromApi(ApiSearchViewModel model);
        ApiSearchViewModel SearchFromApiInHeader(string title);
    }
}
