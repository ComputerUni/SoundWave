using Microsoft.AspNetCore.Mvc;
using SoundWave.Business.Services.Abstract;
using SoundWave.DTO.AuthDtos;

namespace SoundWave.WebUI.Controllers
{
    public class AuthController(IAuthService _authService) : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = await _authService.Login(dto);
            if(result is null)
            {
                ModelState.AddModelError("", "Email / Kullanıcı Adı veya Şifre Hatalı");
                return View(dto);
            }

            Response.Cookies.Append("access_token", result, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddMinutes(10)
            });

            return RedirectToAction("Index", "Home");
        }


    }
}
