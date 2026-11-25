using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SoundWave.Business.Services.Abstract;
using SoundWave.DTO.ArtistDtos;
using SoundWave.WebUI.Constants;

namespace SoundWave.WebUI.Areas.Admin.Controllers
{
    [Area(AppRoles.Admin)]
    [Authorize(Roles = AppRoles.Admin)]
    public class ArtistController(IArtistService _artistService, IAlbumService _albumService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var artists = await _artistService.GetAllAsync();
            return View(artists);
        }

        [HttpGet]
        public async Task<IActionResult> CreateArtist()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateArtist(CreateArtistDto dto)
        {
            if(!ModelState.IsValid)
            {
                return View(dto);
            }

            await _artistService.CreateArtistAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateArtist(int id)
        {
            var artist = await _artistService.GetArtistByIdAsync(id);
            return View(artist);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateArtist(UpdateArtistDto dto)
        {
            await _artistService.UpdateArtistAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteArtist(int id)
        {
            await _artistService.DeleteArtistAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
