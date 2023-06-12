using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class StaffController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StaffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index() //Personel lİSTELEME
        {
            var client = _httpClientFactory.CreateClient();//Bir tane istemci oluştur demek.
            var responseMessage = await client.GetAsync("https://localhost:44384/api/Staff"); //Sadece verileri listeleyeceğimiz için get metodu kullanıldı. bu da api de get kısmından alındı.

            if (responseMessage.IsSuccessStatusCode)//eğer başarılı bir durum kodu dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //bize burdan json data gelir.
                var values = JsonConvert.DeserializeObject<List<StaffViwModel>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddStaff() //Personel EKLEME
        {
            return View();
        }
        [HttpPost] //async ve task yazma şeyi api den çekmek için
        public async Task<IActionResult> AddStaff(AddStaffViewModel model)
        {
            var client = _httpClientFactory.CreateClient(); //bu işlemler api den çekmek için yapılır
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //bizim içeriğimizin dönüşümü için kullanacağımız sınıftır.
            var responseMessage = await client.PostAsync("https://localhost:44384/api/Staff", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        public async Task<IActionResult> DeleteStaff(int id) //Personel SİLME
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44384/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44384/api/Staff/{id}"); // İlk başta id'ye göre getirecek.
            if (responseMessage.IsSuccessStatusCode) // Eğer başarılı dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); // Veriler ilk defa listelenecek sonra güncellenecek.
                var value = JsonConvert.DeserializeObject<UpdateStaffViewModel>(jsonData);
                return View("UpdateStaff", value); // UpdateStaff.cshtml görünümünü ve güncellenmek istenen personel verilerini döndürür.
            }
            return View("UpdateStaff"); // Hata durumunda boş bir görünüm döndürür.
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStaff(UpdateStaffViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44384/api/Staff/", stringContent); //İlk başta id ye göre getirecek.
            if (responseMessage.IsSuccessStatusCode) //eğer başarılı dönerse
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
