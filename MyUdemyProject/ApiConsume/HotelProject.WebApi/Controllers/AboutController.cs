using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        //mutlaka o apinin hangi attribute ile çalışılacağı belirtilmesi gerekiyor.
        [HttpGet]//Verileri sadece getirir.
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetList();
            return Ok(values);
        }
        [HttpPost]//Verileri ekler
        public IActionResult AddAbout(About about)
        {
            _aboutService.TInsert(about);
            return Ok();
        }
        [HttpDelete]//Verileri siler
        public IActionResult DeleteAbout(int id)
        {
            var values = _aboutService.TGetById(id);
            _aboutService.TDelete(values); ;
            return Ok();
        }
        [HttpPut]//Verileri günceller
        public IActionResult UpdateAbout(About about)
        {
            _aboutService.TUpdate(about);
            return Ok();
        }
        //birde ıd ye göre getirme işlemi var.
        [HttpGet("{id}")]//Verileri id ye göre getirir
        public IActionResult GetAbout(int id)
        {
            var values = _aboutService.TGetById(id);
            return Ok(values);
        }
    }
}
