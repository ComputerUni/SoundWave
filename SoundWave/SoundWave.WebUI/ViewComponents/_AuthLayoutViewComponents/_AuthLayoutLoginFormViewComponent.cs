using Microsoft.AspNetCore.Mvc;
using SoundWave.DTO.AuthDtos;

namespace SoundWave.WebUI.ViewComponents._AuthLayoutViewComponents
{
    public class _AuthLayoutLoginFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(LoginDto model)
        {
            return View(model);
        }
    }
}
