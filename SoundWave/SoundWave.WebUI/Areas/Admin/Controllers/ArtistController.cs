using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoundWave.Business.Services.Abstract;
using SoundWave.DTO.ArtistDtos;
using SoundWave.WebUI.Constants;
using SoundWave.WebUI.Extensions;

namespace SoundWave.WebUI.Areas.Admin.Controllers
{
    [Area(AppRoles.Admin)]
    [Authorize(Roles = AppRoles.Admin)]
    public class ArtistController(IArtistService _artistService, IAlbumService _albumService, IValidator<CreateArtistDto> _createArtistValidator, IValidator<UpdateArtistDto> _updateArtistValidator) : Controller
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
            var result = await _createArtistValidator.ValidateAsync(dto);

            if(!result.IsValid)
            {
                result.AddToModelState(ModelState);
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
            var result = await _updateArtistValidator.ValidateAsync(dto);

            if(!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return View(dto);
            }

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
