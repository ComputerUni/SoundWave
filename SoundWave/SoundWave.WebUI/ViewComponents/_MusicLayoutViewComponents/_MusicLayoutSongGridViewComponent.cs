using Microsoft.AspNetCore.Mvc;
using SoundWave.DTO.SongDtos;
using System.Security.Claims;

namespace SoundWave.WebUI.ViewComponents._MusicLayoutViewComponents
{
    public class _MusicLayoutSongGridViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<ResultSongDto> songs)
        {
            var role = UserClaimsPrincipal.FindFirst(ClaimTypes.Role)?.Value;

            ViewBag.UserLevel = role switch
            {
                "Diamond" => 4,
                "Premium" => 3,
                "Standard" => 2,
                _ => 1
            };

            return View(songs);
        }
    }
}
