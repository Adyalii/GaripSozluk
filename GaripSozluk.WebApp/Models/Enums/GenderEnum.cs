using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GaripSozluk.WebApp.Models.Enums
{
    public enum GenderEnum
    {
        [Display(Name = "Kadın")]
        Female,
        [Display(Name = "Erkek")]
        Male,
        [Display(Name = "Kararsız")]
        Other
    }
}

