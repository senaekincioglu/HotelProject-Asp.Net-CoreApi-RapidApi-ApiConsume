 using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();//Bir tane istemci oluştur demek.
            var responseMessage = await client.GetAsync("https://localhost:44384/api/Booking"); //Sadece verileri listeleyeceğimiz için get metodu kullanıldı. bu da api de get kısmından alındı.

            if (responseMessage.IsSuccessStatusCode)//eğer başarılı bir durum kodu dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //bize burdan json data gelir.
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> ApprovedReservation2(int id)
        {
            //amacımız ONAYLAMAK İÇİN güncelleme işlemi yapmak

            var client = _httpClientFactory.CreateClient();
            
           
            var responseMessage = await client.GetAsync($"https://localhost:44384/api/Booking/BookingAproved?id={id}"); //İlk başta id ye göre getirecek.
            if (responseMessage.IsSuccessStatusCode) //eğer başarılı dönerse
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> CancelReservation(int id)
        {
            //amacımız ONAYLAMAK İÇİN güncelleme işlemi yapmak

            var client = _httpClientFactory.CreateClient();


            var responseMessage = await client.GetAsync($"https://localhost:44384/api/Booking/BookingCancel?id={id}"); //İlk başta id ye göre getirecek.
            if (responseMessage.IsSuccessStatusCode) //eğer başarılı dönerse
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> WaitReservation(int id)
        {
            //amacımız ONAYLAMAK İÇİN güncelleme işlemi yapmak

            var client = _httpClientFactory.CreateClient();


            var responseMessage = await client.GetAsync($"https://localhost:44384/api/Booking/BookingWait?id={id}"); //İlk başta id ye göre getirecek.
            if (responseMessage.IsSuccessStatusCode) //eğer başarılı dönerse
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult>UpdateBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage= await client.GetAsync($"https://localhost:44384/api/Booking/{id}");
            
            if (responseMessage.IsSuccessStatusCode) //eğer başarılı dönerse
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44384/api/Booking/UpdateBooking/", stringContent); //İlk başta id ye göre getirecek.
            if (responseMessage.IsSuccessStatusCode) //eğer başarılı dönerse
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
