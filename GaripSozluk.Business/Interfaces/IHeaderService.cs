using GaripSozluk.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace GaripSozluk.Business.Interfaces
{
   public interface IHeaderService
    {
        ICollection<HeaderViewModel> GetAllCategory(int id);
        //int AddHeader(string headerName, ClaimsPrincipal contextUser, int categoryId);
        //int AddHeader();
        //Todo: Derste de söylediğim gibi buraya da not ediyorum. Metotlarda çok fazla parametre kullanmaktan kaçınalım. Bunu alttaki Örnek 1'deki şekilde değiştirmek daha doğru olur. Hatta Örnek 2 daha doğru bir kullanım olabilir. Neden dersen çünkü sen Header yani başlık eklemeyi yarın bir gün kodda geliştirme yaparken başka bir servisten çağırmak isteyebilirsin. Mesela ileride bir bot yazdığını düşün, her gün gece 01:00 da bu bot çalışıp bir başlık yani header kaydı açacak. Öyle bir iş için gidip BotService diye bir servis yazdığını düşün. İçerisinde tekrardan header ekleme yazmak yerine gidip o servis içerisinde, HeaderService'in alttaki AddHeader metodunu çağırdığını düşün. Sen metodu çağırdığında eğer bu haliyleyse gidip addheader'ın ikinci parametre tipi için bir nesne yaratman gerekebilir. Ama burada sana zaten nesne lazım değil. Sadece contextuser nesnesi içindeki userId lazım. Bu yüzden Örnek 2 gibi yazıp o metoda sadece int tipte userId yollarsan daha kolay bir çözüm olabilir. 

        //Örnek 1: int AddHeader(HeaderViewModel model,ClaimsPrincipal contextUser);
        //Örnek 2: int AddHeader(HeaderViewModel model,int userId);
    }
}
