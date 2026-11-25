using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SoundWave.Business.Services.Abstract;
using SoundWave.Business.Services.Concrete;
using SoundWave.DTO.AlbumDtos;
using SoundWave.DTO.SongDtos;
using SoundWave.Entity.Enums;

namespace SoundWave.WebUI.Areas.Admin.Controllers
{
    public class SongController(ISongService _songService, IAlbumService _albumService) : BaseAdminController
    {
        private async Task GetAlbums()
        {
            var albums = await _albumService.GetAllAsync();
            var sortedAlbums = albums.OrderBy(x => x.Title).ToList();
            ViewBag.albums = (from album in sortedAlbums
                               select new SelectListItem
                               {
                                   Text = album.Title,
                                   Value = album.Id.ToString()
                               }).ToList();

            ViewBag.SubscriptionLevels = Enum.GetValues(typeof(SubscriptionLevel))
                .Cast<SubscriptionLevel>()
                .Select(x => new SelectListItem
                {
                    Text = x.ToString(),
                    Value = ((int)x).ToString()
                }).ToList();
        }


        public async Task<IActionResult> Index()
        {
            var songs = await _songService.GetAllAsync();
            return View(songs);
        }

        [HttpGet]
        public async Task<IActionResult> CreateSong()
        {
            await GetAlbums();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSong(CreateSongDto dto)
        {
            if(!ModelState.IsValid)
            {
                await GetAlbums();
                return View(dto);
            }

            await _songService.CreateSongAsync(dto);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> UpdateSong(int id)
        {
            await GetAlbums();
            var song = await _songService.GetByIdAsync(id);
            return View(song);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSong(UpdateSongDto dto)
        {
            if (!ModelState.IsValid)
            {
                await GetAlbums();
                return View(dto);
            }
            await _songService.UpdateSongAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteSong(int id)
        {
            await _songService.DeleteSongAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
