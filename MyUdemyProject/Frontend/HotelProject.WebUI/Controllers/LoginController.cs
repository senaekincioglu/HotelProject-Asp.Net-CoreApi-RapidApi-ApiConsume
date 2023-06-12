using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.LoginDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]//Bu sayfaya izin ver demek. Yani bu sayfaya erişim izni olsun.
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;//SignInManager: 
        //SignInManager ilk başta hata veriyor ctrl nokta yapıp ıdentity kütüphanesini eklemen lazım.

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;//Bunun içinde en üstteki class a ctrl nokta yapılarak generate conscructor a tıklanır.
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        
        public async Task< IActionResult> Index(LoginUserDto loginUserDto)
        {

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginUserDto.Username, loginUserDto.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Staff");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }
    }
}
