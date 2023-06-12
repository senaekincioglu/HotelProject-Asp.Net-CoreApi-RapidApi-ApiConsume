using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Inbox() //Gelen mesajlar
        {

            
            var client = _httpClientFactory.CreateClient();//Bir tane istemci oluştur demek.
            var responseMessage = await client.GetAsync("https://localhost:44384/api/Contact"); //Sadece verileri listeleyeceğimiz için get metodu kullanıldı. bu da api de get kısmından alındı.

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44384/api/Contact/GetContactCount"); 

            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:44384/api/SendMessage/GetSendMessageCount"); 

            if (responseMessage.IsSuccessStatusCode)//eğer başarılı bir durum kodu dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //bize burdan json data gelir.
                var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);

                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                ViewBag.contactCount = jsonData2;

                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                ViewBag.sendMessageCount = jsonData3;
                return View(values);
            }
           
            return View();
        }

        public async Task<IActionResult> SendBox() //Gönderilen Kutusu
        {
            var client = _httpClientFactory.CreateClient();//Bir tane istemci oluştur demek.
            var responseMessage = await client.GetAsync("https://localhost:44384/api/SendMessage"); //Sadece verileri listeleyeceğimiz için get metodu kullanıldı. bu da api de get kısmından alındı.

            if (responseMessage.IsSuccessStatusCode)//eğer başarılı bir durum kodu dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //bize burdan json data gelir.
                var values = JsonConvert.DeserializeObject<List<ResultSendBoxDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddSendMessage() //Mesaj Gönderme işlemi yani ekleme işlemi oluyor.Mesajı oluşturup Diğer tarafa ekliyorsun.
        {
            return View();
        }
        [HttpPost] //async ve task yazma şeyi api den çekmek için
        public async Task<IActionResult> AddSendMessage(CreateSendMessage createSendMessage)
        {

            createSendMessage.SenderMail = "admin@gmail.com";//Gönderen mail
            createSendMessage.SenderName = "admin";//Gönderen adı
            createSendMessage.Date=DateTime.Parse(DateTime.Now.ToShortDateString());//gönderme tarihi
                                                                              
            var client = _httpClientFactory.CreateClient(); //bu işlemler api den çekmek için yapılır
            var jsonData = JsonConvert.SerializeObject(createSendMessage);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //bizim içeriğimizin dönüşümü için kullanacağımız sınıftır.
            var responseMessage = await client.PostAsync("https://localhost:44384/api/SendMessage", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SendBox"); //Gönderilen kutusuna yönlendirsin.
            }

            return View();
        }

        public PartialViewResult SidebarAdminContactPartial()
        {
            return PartialView();
        }
        public PartialViewResult SidebarAdminContactCategoryPartial()
        {
            return PartialView();
        }
        public async Task< IActionResult> MessageDetailsBySendBox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44384/api/SendMessage/{id}"); // İlk başta id'ye göre getirecek.
            if (responseMessage.IsSuccessStatusCode) // Eğer başarılı dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); // Veriler ilk defa listelenecek sonra güncellenecek.
                var value = JsonConvert.DeserializeObject<GetMessageByIDDto>(jsonData);
                return View("MessageDetails", value); // 
            }
            return View("MessageDetails"); // Hata durumunda boş bir görünüm döndürür.
        }
        public async Task<IActionResult> MessageDetailsByInbox(int id)//Gelen kutusunun detayları BİZE GÖNDERİLEN
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44384/api/Contact/{id}"); // Inbox dan geleni contact da tutuyoruz o yüzden contact yazıldı.
            if (responseMessage.IsSuccessStatusCode) // Eğer başarılı dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); // Veriler ilk defa listelenecek sonra güncellenecek.
                var value = JsonConvert.DeserializeObject<InboxContactDto>(jsonData);
                return View("MessageDetails", value); // 
            }
            return View("MessageDetails"); // Hata durumunda boş bir görünüm döndürür.
        }

        //public async Task<IActionResult> GetContactCount() //Gelen mesajlar
        //{
        //    var client = _httpClientFactory.CreateClient();//Bir tane istemci oluştur demek.
        //    var responseMessage = await client.GetAsync("https://localhost:44384/api/Contact/GetContactCount"); //Sadece verileri listeleyeceğimiz için get metodu kullanıldı. bu da api de get kısmından alındı.

        //    if (responseMessage.IsSuccessStatusCode)//eğer başarılı bir durum kodu dönerse
        //    {
        //        var jsonData = await responseMessage.Content.ReadAsStringAsync(); //bize burdan json data gelir.
        //        //var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);
        //        ViewBag.data = jsonData;
        //        return View();
        //    }
        //    return View();
        //}


    }
}
