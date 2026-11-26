using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoundWave.Business.Services.Abstract;
using SoundWave.DTO.AuthDtos;
using SoundWave.DTO.SelectPlanDtos;
using SoundWave.Entity.Entities;
using SoundWave.Entity.Enums;
using System.Security.Claims;

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

            var user = await _userManager.FindByNameAsync(dto.UserNameOrEmail) ?? await _userManager.FindByEmailAsync(dto.UserNameOrEmail);
            var roles = await _userManager.GetRolesAsync(user);

            if(roles.Contains("Admin"))
                return RedirectToAction("Index", "Artist", new { area = "Admin" });

            return RedirectToAction("Discover", "Music");
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
        public async Task<IActionResult> SelectPlan(SubscriptionLevel? targetLevel)
        {
            SubscriptionLevel currentLevel = SubscriptionLevel.Free;
            if(User.Identity != null && User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                if(user != null)
                {
                    currentLevel = user.SubscriptionLevel;
                }
            }

            ViewBag.CurrentLevel = currentLevel;
            ViewBag.TargetLevel = targetLevel;

            var model = new SelectPlanDto
            {
                SubscriptionLevel = currentLevel
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SelectPlan(SelectPlanDto dto)
        {
            int userId;

            if (TempData["UserId"] != null)
            {
                userId = (int)TempData["UserId"];
            }

            else
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userIdClaim == null) return RedirectToAction("Login");
                userId = int.Parse(userIdClaim);
            }


            var token = await _authService.SelectPlanAsync(userId, dto.SubscriptionLevel);
            Response.Cookies.Append("access_token", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddMinutes(10)
            });
            return RedirectToAction("Discover", "Music");
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("access_token");
            return RedirectToAction("Login", "Auth");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
