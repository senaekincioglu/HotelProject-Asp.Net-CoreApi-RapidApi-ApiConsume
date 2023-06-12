using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiJwt.Models;

namespace WebApiJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult TokenOlustur() //test metodu çalıştığı zaman bir token üretmeli.
            //yani test actionun içine gidersek bir token üretmeli.
        {
            return Ok(new CreateToken().TokenCreate());
        }

        [HttpGet("[action]")]
        public IActionResult AdminTokenOlustur() //test metodu çalıştığı zaman bir token üretmeli.
                                            //yani test actionun içine gidersek bir token üretmeli.
        {
            return Ok(new CreateToken().TokenCreateAdmin());
        }

        //burda herhangi bir sayfa tanımlayacaksak:
        [Authorize]
        [HttpGet("[action]")]
        public IActionResult Test2() //TokenOlustur dan geliyor
        {
            return Ok("Hoşgeldiniz");
        }

        [Authorize(Roles ="Admin,Visitor")]
        [HttpGet("[action]")]
        public IActionResult Test3() //AdminTokenOlustur dan geliyor.
        {
            return Ok("Token Başarılı Bir Şekilde Giriş Yaptı");
        }
    }
}
