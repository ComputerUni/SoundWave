using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoundWave.Business.Services.Abstract;
using SoundWave.WebUI.Constants;

namespace SoundWave.WebUI.Areas.Admin.Controllers
{
    [Area(AppRoles.Admin)]
    [Authorize(Roles = AppRoles.Admin)]
    public class DashboardController(IDashboardService _dashboardService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var data = await _dashboardService.GetDashboardDataAsync();
            return View(data);
        }
    }
}
