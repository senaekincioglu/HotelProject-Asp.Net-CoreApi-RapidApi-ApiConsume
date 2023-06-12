using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Room2Controller : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper; //Room sınıfını bundan alır.

        public Room2Controller(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService; //üstteki class a ctrl nokta yapılarak generate consctuctor yapılarak bu gelir.
            _mapper = mapper;/* üstteki_mapper sonuna da generace parametrers yapılarak bu gelir.*/
        }
        [HttpGet]//Listeleme
        public IActionResult Index() //Room2 deki veriler geliyor mu bunun kontrolü yapılır.
        {
            var values = _roomService.TGetList();
            return Ok(values);
        }
        //Esas olay ekleme işlemindedir.
        [HttpPost]//Ekleme

        public IActionResult AddRoom(RoomAddDto roomAddDto)//Dışarıdan parametre alır ve bu parametre de bizim oluşturduğumuz Dto tipinde olur.
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var values = _mapper.Map<Room>(roomAddDto);
            _roomService.TInsert(values);
            return Ok();
        }
        [HttpPut]//Güncelleme
        public IActionResult UpdateRoom(UpdateRoomDto updateRoomDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values=_mapper.Map<Room>(updateRoomDto);
            _roomService.TUpdate(values);
            return Ok("Başarıyla güncellendi");
        }
    }
}
