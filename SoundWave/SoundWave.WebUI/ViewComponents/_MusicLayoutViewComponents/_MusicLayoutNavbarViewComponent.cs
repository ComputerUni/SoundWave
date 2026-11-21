using Microsoft.AspNetCore.Mvc;
using SoundWave.WebUI.Models;
using System.Security.Claims;

namespace SoundWave.WebUI.ViewComponents._MusicLayoutViewComponents
{
    public class _MusicLayoutNavbarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var userName = UserClaimsPrincipal.FindFirst(ClaimTypes.Name)?.Value;
            var role = UserClaimsPrincipal.FindFirst(ClaimTypes.Role)?.Value;

            var model = new NavbarViewModel
            {
                UserName = userName,
                Role = role
            };

            return View(model);
        }
    }
}
