using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoundWave.Business.Services.Abstract;
using SoundWave.DTO.UserDtos;
using SoundWave.WebUI.Constants;

namespace SoundWave.WebUI.Areas.Admin.Controllers
{
    [Area(AppRoles.Admin)]
    [Authorize(Roles = AppRoles.Admin)]
    public class UserController(IUserService _userService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsersAsync();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> AssignPackage(int id)
        {
            var model = await _userService.GetUserForPackageUpdateAsync(id);
            if(model == null)
            {
                TempData["ErrorMessage"] = "Kullanıcı bulunamadı";
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AssignPackage(AssignPackageDto dto)
        {
            var isUpdated = await _userService.UpdateUserPackageAsync(dto);
            if(!isUpdated)
            {
                TempData["ErrorMessage"] = "Paket güncellenemedi (Admin hesabı değiştirilemez veya kullanıcı bulunamadı).";
                return RedirectToAction(nameof(Index));
            }

            TempData["SuccessMessage"] = "Kullanıcı paketi başarıyla güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ToggleLockout(int id)
        {
            var result = await _userService.ToggleUserLockoutAsync(id);
            if (!result)
            {
                TempData["ErrorMessage"] = "Kullanıcı durumu güncellenemedi.";
                return RedirectToAction(nameof(Index));
            }

            TempData["SuccessMessage"] = "Kullanıcı erişim durumu güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (!result)
            {
                TempData["ErrorMessage"] = "Kullanıcı silinemedi (Admin hesabı silinemez veya kullanıcı bulunamadı)..";
                return RedirectToAction(nameof(Index));
            }

            TempData["SuccessMessage"] = "Kullanıcı başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }
    }
}
