using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RapidApiConsume.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Globalization;
using System.Runtime.Intrinsics.X86;

namespace RapidApiConsume.Controllers
{
    public class SearchLocationIDController : Controller
    {
        public async Task<IActionResult> Index(string cityName)
        {
            if (!string.IsNullOrEmpty(cityName))//eğer cityname dolu ise parantez içindeki işlemleri yapar
            {
                List<BookingApiLocationSearchViewModel> model = new List<BookingApiLocationSearchViewModel>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityName}&locale=en-gb"),
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
                    model = JsonConvert.DeserializeObject<List<BookingApiLocationSearchViewModel>>(body);
                    return View(model.Take(1).ToList());//Take(1) kullanmanın amacı, koleksiyondan veya sorgudan yalnızca belirli bir öğeyi almak istediğimizde, diğer öğeleri yüklemek veya işlemek yerine yalnızca ilk öğeyle ilgilenmek için kullanmaktır. Bu, gereksiz veri işlemesini ve kaynak kullanımını azaltabilir.
                }
                //cityName doluysa bu aşağıdaki işlemleriş yapar
           
            }
            else// eğer cityname boş ise aşağıdaki parantez içindeki işlemleri yapar. Yine aynıları olacak. Aradaki fark:
            //Üstteki if de locations?name=paris yazan kısım silinir ve başına $ sembolü eklenerek locations?name= kısmına locations?name={cityName} yazılır.

            {
                List<BookingApiLocationSearchViewModel> model = new List<BookingApiLocationSearchViewModel>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/locations?name=Paris&locale=en-gb"),
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
                    model = JsonConvert.DeserializeObject<List<BookingApiLocationSearchViewModel>>(body);
                    return View(model.Take(1).ToList());//Take(1) kullanmanın amacı, koleksiyondan veya sorgudan yalnızca belirli bir öğeyi almak istediğimizde, diğer öğeleri yüklemek veya işlemek yerine yalnızca ilk öğeyle ilgilenmek için kullanmaktır. Bu, gereksiz veri işlemesini ve kaynak kullanımını azaltabilir.
                }
                //cityName doluysa bu aşağıdaki işlemleriş yapar

            }
        }
        }
    }

