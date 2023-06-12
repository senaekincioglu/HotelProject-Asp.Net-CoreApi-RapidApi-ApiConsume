using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //dosya işlem contoller 
    public class FileProcessController : ControllerBase
    {
        [HttpPost] //ilgili metin dosyasını api üzerinden projeye istediğimiz klasöre dahil eder.
        public async Task<IActionResult> UploadFile([FromForm]IFormFile file)
        {
            //kullanıcı mesela metin indirecek. Kendi pc sine indirdiğinde pcde de aynı isimde dosya varsa üzerine mi eklicek veya değiştirecek mi diye sorgulamamak için farklı isimle kaydetmesi için yapılan işlem:
            //sunucuda mesela dosya yükleniyor.
            var fileName=Guid.NewGuid()+Path.GetExtension(file.FileName);

            //örneğin api porjesi içerisindeki files klasörüne kaydetsin istiyoruz
            var path =Path.Combine(Directory.GetCurrentDirectory(), "files/"+fileName);

            var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);
            return Created("", file);
        }
    }
}
