using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class AdminAboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminAboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();//Bir tane istemci oluştur demek.
            var responseMessage = await client.GetAsync("https://localhost:44384/api/About"); //Sadece verileri listeleyeceğimiz için get metodu kullanıldı. bu da api de get kısmından alındı.

            if (responseMessage.IsSuccessStatusCode)//eğer başarılı bir durum kodu dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //bize burdan json data gelir.
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44384/api/About/{id}"); // İlk başta id'ye göre getirecek.
            if (responseMessage.IsSuccessStatusCode) // Eğer başarılı dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); // Veriler ilk defa listelenecek sonra güncellenecek.
                var value = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
                return View("UpdateAbout", value); // UpdateStaff.cshtml görünümünü ve güncellenmek istenen personel verilerini döndürür.
            }
            return View("UpdateAbout"); // Hata durumunda boş bir görünüm döndürür.
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44384/api/About/", stringContent); //İlk başta id ye göre getirecek.
            if (responseMessage.IsSuccessStatusCode) //eğer başarılı dönerse
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
