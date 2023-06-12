using HotelProject.WebUI.Dtos.GuestDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task <IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();//Bir tane istemci oluştur demek.
            var responseMessage = await client.GetAsync("https://localhost:44384/api/DashboardWidgets/StaffCount"); //Sadece verileri listeleyeceğimiz için get metodu kullanıldı. bu da api de get kısmından alındı.  
            var jsonData = await responseMessage.Content.ReadAsStringAsync(); //bize burdan json data gelir.
                ViewBag.staffCount=jsonData;
               
            


            var client2 = _httpClientFactory.CreateClient();//Bir tane istemci oluştur demek.
            var responseMessage2 = await client2.GetAsync("https://localhost:44384/api/DashboardWidgets/BookingCount"); //Sadece verileri listeleyeceğimiz için get metodu kullanıldı. bu da api de get kısmından alındı.
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync(); //bize burdan json data gelir.
            ViewBag.bookingCount = jsonData2;

            var client3 = _httpClientFactory.CreateClient();//Bir tane istemci oluştur demek.
            var responseMessage3 = await client3.GetAsync("https://localhost:44384/api/DashboardWidgets/AppUserCount"); //Sadece verileri listeleyeceğimiz için get metodu kullanıldı. bu da api de get kısmından alındı.
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync(); //bize burdan json data gelir.
            ViewBag.appUserCount = jsonData3;

            var client4 = _httpClientFactory.CreateClient();//Bir tane istemci oluştur demek.
            var responseMessage4 = await client4.GetAsync("https://localhost:44384/api/DashboardWidgets/RoomCount"); //Sadece verileri listeleyeceğimiz için get metodu kullanıldı. bu da api de get kısmından alındı.
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync(); //bize burdan json data gelir.
            ViewBag.roomCount = jsonData4;



            return View();
        }
    }
}
