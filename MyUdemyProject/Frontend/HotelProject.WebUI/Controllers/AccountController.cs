using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize] // Oturum açma yetkisi gerektirir
        public IActionResult Logout()
        {
            // Oturumu sonlandır
            HttpContext.SignOutAsync();

            // Login/Index'e yönlendirme yap
            return RedirectToAction("Index", "Login");
        }
    }
}
