using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using RapidApiConsume.Models;
using Newtonsoft.Json;
using System.Linq;

namespace RapidApiConsume.Controllers
{
    public class ExchangeController : Controller
    {
        public async Task< IActionResult> Index() //ASYNC ye çevrildi.
        {
           //List<ExchangeViewModel> exchangeViewModels = new List<ExchangeViewModel>(); //Buna burda ihtiyaç yok yazıp silindi.
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=TRY&locale=en-gb"),
                Headers =
    {
        { "X-RapidAPI-Key", "e4335bd6b2mshcbdb3a6ed79bc02p1fbd10jsnc727fb167bda" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<ExchangeViewModel>(body);//Bu yazıldı.
                return View(values.exchange_rates.ToList());//Bu yazıldı
            }
        }
    }
}
