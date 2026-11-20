using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoundWave.Business.Services.Abstract;
using SoundWave.DTO.AuthDtos;
using SoundWave.DTO.SelectPlanDtos;
using SoundWave.Entity.Entities;

namespace SoundWave.WebUI.Controllers
{
    public class AuthController(IAuthService _authService, ITokenService _tokenService, UserManager<AppUser> _userManager) : Controller
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
            if (result is null)
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

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (dto.Password != dto.ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "Şifreler birbiriyle uyumlu değil.");
                return View();
            }

            var result = await _authService.Register(dto);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(dto.UserName);
                TempData["UserId"] = user.Id;
                return RedirectToAction("SelectPlan");
            }

            return View();
        }


        [HttpGet]
        public IActionResult SelectPlan()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SelectPlan(SelectPlanDto dto)
        {
            var userId = (int)TempData["UserId"];
            var token = await _authService.SelectPlanAsync(userId, dto.SubscriptionLevel);
            Response.Cookies.Append("access_token", token, new CookieOptions
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
