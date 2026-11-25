using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SoundWave.Business.Services.Abstract;
using SoundWave.DTO.AlbumDtos;
using SoundWave.WebUI.Constants;

namespace SoundWave.WebUI.Areas.Admin.Controllers
{
    [Area(AppRoles.Admin)]
    [Authorize(Roles = AppRoles.Admin)]
    public class AlbumController(IAlbumService _albumService, IArtistService _artistService) : Controller
    {
        private async Task GetArtists()
        {
            var artists = await _artistService.GetAllAsync();
            var sortedArtists = artists.OrderBy(x => x.Name).ToList();
            ViewBag.artists = (from artist in sortedArtists
                               select new SelectListItem
                               {
                                   Text = artist.Name,
                                   Value = artist.Id.ToString()
                               }).ToList();
        }

        public async Task<IActionResult> Index()
        {
            var albums = await _albumService.GetAllAsync();
            return View(albums);
        }

        [HttpGet]
        public async Task<IActionResult> CreateAlbum()
        {
            await GetArtists();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlbum(CreateAlbumDto dto)
        {
            if (!ModelState.IsValid)
            {
                await GetArtists();
                return View(dto);
            }
            await _albumService.CreateAlbumAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAlbum(int id)
        {
            await GetArtists();
            var album = await _albumService.GetAlbumByIdAsync(id);
            return View(album);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAlbum(UpdateAlbumDto dto)
        {
            if (!ModelState.IsValid)
            {
                await GetArtists();
                return View(dto);
            }
            await _albumService.UpdateAlbumAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteAlbum(int id)
        {
            await _albumService.DeleteAlbumAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
