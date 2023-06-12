using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class ServiceController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index() 
        {
            var client = _httpClientFactory.CreateClient();//Bir tane istemci oluştur demek.
            var responseMessage = await client.GetAsync("https://localhost:44384/api/Service"); //Sadece verileri listeleyeceğimiz için get metodu kullanıldı. bu da api de get kısmından alındı.

            if (responseMessage.IsSuccessStatusCode)//eğer başarılı bir durum kodu dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //bize burdan json data gelir.
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddService() 
        {
            return View();
        }
        [HttpPost] //async ve task yazma şeyi api den çekmek için
        public async Task<IActionResult> AddService(CreateServiceDto createServiceDto)
        {
            if (!ModelState.IsValid) //Model geçersizse hata mesajlarını döndür
            {
                return View();
            }
            //eğer model geçerliyse aşağıdaki işlemler gerçekleştirilir.
            var client = _httpClientFactory.CreateClient(); //bu işlemler api den çekmek için yapılır
            var jsonData = JsonConvert.SerializeObject(createServiceDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //bizim içeriğimizin dönüşümü için kullanacağımız sınıftır.
            var responseMessage = await client.PostAsync("https://localhost:44384/api/Service", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        public async Task<IActionResult> DeleteService(int id) 
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44384/api/Service/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44384/api/Service/{id}"); // İlk başta id'ye göre getirecek.
            if (responseMessage.IsSuccessStatusCode) // Eğer başarılı dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); // Veriler ilk defa listelenecek sonra güncellenecek.
                var value = JsonConvert.DeserializeObject<UpdateServiceDto>(jsonData);
                return View("UpdateService", value); // UpdateStaff.cshtml görünümünü ve güncellenmek istenen personel verilerini döndürür.
            }
            return View("UpdateService"); // Hata durumunda boş bir görünüm döndürür.
        }
        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateServiceDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44384/api/Service/", stringContent); //İlk başta id ye göre getirecek.
            if (responseMessage.IsSuccessStatusCode) //eğer başarılı dönerse
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
   }

