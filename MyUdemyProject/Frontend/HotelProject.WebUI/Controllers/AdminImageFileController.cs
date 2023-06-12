using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class AdminImageFileController : Controller
    // bir dosya yükleme işlemi gerçekleştiren bir controller ve view i tanımlar.
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Index(IFormFile file)
        {
            var stream = new MemoryStream();//akışı oluşturur
            await file.CopyToAsync(stream);//dosya kopyalanır
            var bytes=stream.ToArray();//akıştaki dosyayı byte olarak tutar

            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            multipartFormDataContent.Add(byteArrayContent,"file",file.FileName);
            var httpclient=new HttpClient();
           await httpclient.PostAsync("https://localhost:44384/api/FileImage", multipartFormDataContent);
          
            return View();
        }
    }
}
