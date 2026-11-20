using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoundWave.Business.Services.Abstract;

namespace SoundWave.WebUI.Controllers
{
    public class MusicController(ISongService _songService) : Controller
    {
        [Authorize]
        public async Task<IActionResult> Discover()
        {
            var songs = await _songService.GetAllAsync();
            return View(songs);
        }

        [Authorize(Policy = "CanListenFree")]
        public async Task<IActionResult> PlayFree(int id)
        {
            var song = await _songService.GetSongByIdAsync(id);
            return View(song);
        }

        [Authorize(Policy = "CanListenStandard")]
        public async Task<IActionResult> PlayStandard(int id)
        {
            var song = await _songService.GetSongByIdAsync(id);
            return View(song);
        }

        [Authorize(Policy = "CanListenPremium")]
        public async Task<IActionResult> PlayPremium(int id)
        {
            var song = await _songService.GetSongByIdAsync(id);
            return View(song);
        }

        [Authorize(Policy = "CanListenDiamond")]
        public async Task<IActionResult> PlayDiamond(int id)
        {
            var song = await _songService.GetSongByIdAsync(id);
            return View(song);
        }
    }
}
