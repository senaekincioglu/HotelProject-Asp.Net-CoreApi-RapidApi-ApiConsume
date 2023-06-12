using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _guestService;

        public GuestController(IGuestService guestService)
        {
            _guestService = guestService;
        }
        //mutlaka o apinin hangi attribute ile çalışılacağı belirtilmesi gerekiyor.
        [HttpGet]//Verileri sadece getirir.
        public IActionResult GuestList()
        {
            var values = _guestService.TGetList();
            return Ok(values);
        }
        [HttpPost]//Verileri ekler
        public IActionResult AddGuest(Guest guest)
        {
            _guestService.TInsert(guest);
            return Ok();
        }
        [HttpDelete("{id}")]//Verileri siler
        public IActionResult DeleteGuest(int id)
        {
            var values = _guestService.TGetById(id);
            _guestService.TDelete(values); ;
            return Ok();
        }
        [HttpPut]//Verileri günceller
        public IActionResult UpdateGuest(Guest guest)
        {
            _guestService.TUpdate(guest);
            return Ok();
        }
        //birde ıd ye göre getirme işlemi var.
        [HttpGet("{id}")]//Verileri id ye göre getirir
        public IActionResult GetGuest(int id)
        {
            var values = _guestService.TGetById(id);
            return Ok(values);
        }
    }
}

