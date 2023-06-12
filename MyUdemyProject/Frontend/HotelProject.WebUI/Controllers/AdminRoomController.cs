using HotelProject.WebUI.Dtos.RoomDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class AdminRoomController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminRoomController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index() //Personel lİSTELEME
        {
            var client = _httpClientFactory.CreateClient();//Bir tane istemci oluştur demek.
            var responseMessage = await client.GetAsync("https://localhost:44384/api/Room"); //Sadece verileri listeleyeceğimiz için get metodu kullanıldı. bu da api de get kısmından alındı.

            if (responseMessage.IsSuccessStatusCode)//eğer başarılı bir durum kodu dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //bize burdan json data gelir.
                var values = JsonConvert.DeserializeObject<List<ResultRoomDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddRoom() //Personel EKLEME
        {
            return View();
        }
        [HttpPost] //async ve task yazma şeyi api den çekmek için
        public async Task<IActionResult> AddRoom(CreateRoomDto createRoomDto)
        {
            var client = _httpClientFactory.CreateClient(); //bu işlemler api den çekmek için yapılır
            var jsonData = JsonConvert.SerializeObject(createRoomDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //bizim içeriğimizin dönüşümü için kullanacağımız sınıftır.
            var responseMessage = await client.PostAsync("https://localhost:44384/api/Room", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        public async Task<IActionResult> DeleteRoom(int id) //Personel SİLME
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44384/api/Room/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateRoom(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44384/api/Room/{id}"); // İlk başta id'ye göre getirecek.
            if (responseMessage.IsSuccessStatusCode) // Eğer başarılı dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); // Veriler ilk defa listelenecek sonra güncellenecek.
                var value = JsonConvert.DeserializeObject<UpdateRoomDto>(jsonData);
                return View("UpdateRoom", value); // UpdateStaff.cshtml görünümünü ve güncellenmek istenen personel verilerini döndürür.
            }
            return View("UpdateRoom"); // Hata durumunda boş bir görünüm döndürür.
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRoom(UpdateRoomDto updateRoomDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateRoomDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44384/api/Room/", stringContent); //İlk başta id ye göre getirecek.
            if (responseMessage.IsSuccessStatusCode) //eğer başarılı dönerse
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
