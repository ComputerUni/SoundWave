using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoundWave.Business.Services.Abstract;
using SoundWave.Entity.Entities;
using SoundWave.Entity.Enums;

namespace SoundWave.WebUI.Controllers
{
    public class AlbumController(IAlbumService _albumService, UserManager<AppUser> _userManager) : Controller
    {
        public async Task<IActionResult> Detail(int id)
        {
            var album = await _albumService.GetAlbumWithDetailsAsync(id);
            if(album is null)
            {
                return NotFound();
            }

            int userLevel = (int)SubscriptionLevel.Free;
            if(User.Identity != null && User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                if(user != null)
                {
                    userLevel = (int)user.SubscriptionLevel;
                }
            }
            ViewBag.UserLevel = userLevel;
            return View(album);
        }
    }
}
