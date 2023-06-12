using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.WebUI.Dtos.SubscribeDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult _SubscribePartial()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task< IActionResult >_SubscribePartial(CreateSubscribeDto createSubscribeDto)
        {
            
            var client = _httpClientFactory.CreateClient(); //bu işlemler api den çekmek için yapılır
            var jsonData = JsonConvert.SerializeObject(createSubscribeDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //bizim içeriğimizin dönüşümü için kullanacağımız sınıftır.
             await client.PostAsync("https://localhost:44384/api/Subscribe", stringContent);
           
                return RedirectToAction("Index","Default");
        }
    }
}
