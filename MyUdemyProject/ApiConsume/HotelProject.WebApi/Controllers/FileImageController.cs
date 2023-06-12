using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileImageController : ControllerBase
    {
        [HttpPost] //ilgili klasörü veya fotoğrafı api üzerinden projeye istediğimiz klasöre dahil eder.
        public async Task<IActionResult> UploadImage([FromForm]IFormFile file)
        {
            //kullanıcı mesela resim indiricek veya çekicek. Kendi pc sine indirdiğinde pcde de aynı isimde resim varsa üzerine mi eklicek veya değiştirecek mi diye sorgulamamak için farklı isimle kaydetmesi için yapılan işlem:
            //sunucuda mesela dosya yükleniyor.
            var fileName=Guid.NewGuid()+Path.GetExtension(file.FileName);

            //örneğin api porjesi içerisindeki images klasörüne kaydetsin istiyoruz
            var path =Path.Combine(Directory.GetCurrentDirectory(), "images/"+fileName);

            var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);
            return Created("", file);
        }
    }
}
