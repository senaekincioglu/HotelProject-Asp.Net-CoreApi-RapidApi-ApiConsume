using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Collections.Generic;
using RapidApiConsume.Models;
using Newtonsoft.Json;

namespace RapidApiConsume.Controllers
{
    public class ImdbController : Controller
    {
        public async Task< IActionResult> Index()
        { 
            List<ApiMovieViewModel> apiMovieViewModels = new List<ApiMovieViewModel>(); //Bunu biz + olarak yazdık. Nesne örneği alınmış oldu.
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),//İstek yapılacak adres
                Headers =
    {
        { "X-RapidAPI-Key", "e4335bd6b2mshcbdb3a6ed79bc02p1fbd10jsnc727fb167bda" },//ilgili apiye istekte bulunurken kullanacağımız key
        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },//api sağlayıcı linki.
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                apiMovieViewModels=JsonConvert.DeserializeObject<List<ApiMovieViewModel>>(body); /*body değişkenindeki JSON dizesi ApiMovieViewModel sınıfı türündeki nesnelerin bir listesine dönüştürülür ve apiMovieViewModels değişkenine atanır.Böylece, bu değişken üzerinden dönüştürülmüş JSON verilerine erişebilirsiniz.*/ /*Bunu da kendimiz yazdık*/
                return View(apiMovieViewModels);
             
            }
        }
    }
}

