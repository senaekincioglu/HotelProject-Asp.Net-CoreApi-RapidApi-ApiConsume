using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkLocationController : ControllerBase
    {
        private readonly IWorkLocationService _workLocationService ;

        public WorkLocationController(IWorkLocationService workLocationService)
        {
            _workLocationService = workLocationService;
        }
        //mutlaka o apinin hangi attribute ile çalışılacağı belirtilmesi gerekiyor.
        [HttpGet]//Verileri sadece getirir.
        public IActionResult WorkLocationList()
        {
            var values = _workLocationService.TGetList();
            return Ok(values);
        }
        [HttpPost]//Verileri ekler
        public IActionResult AddWorkLocation(WorkLocation workLocation)
        {
            _workLocationService.TInsert(workLocation);
            return Ok();
        }
        [HttpDelete("{id}")]//Verileri siler
        public IActionResult DeleteWorkLocation(int id)
        {
            var values = _workLocationService.TGetById(id);
            _workLocationService.TDelete(values); ;
            return Ok();
        }
        [HttpPut]//Verileri günceller
        public IActionResult UpdateWorkLocation(WorkLocation workLocation)
        {
            _workLocationService.TUpdate(workLocation);
            return Ok();
        }
        //birde ıd ye göre getirme işlemi var.
        [HttpGet("{id}")]//Verileri id ye göre getirir
        public IActionResult GetWorkLocation(int id)
        {
            var values = _workLocationService.TGetById(id);
            return Ok(values);
        }
    }
}
