using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        //Sadece listeleme yapılacak hepsini almamıza gerek yok.
        private readonly IAppUserService _appUserService;

        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        //[HttpGet]
        //public IActionResult UserListWithWorkLocation()
        //{
        //    var values = _appUserService.TUserListWithWorkLocation();
        //    return Ok(values);
        //}
        [HttpGet()]
        public IActionResult AppUserList()
        {
            var values=_appUserService.TGetList();
            return Ok(values);
        }
    }
}
