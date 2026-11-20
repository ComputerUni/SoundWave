using Microsoft.AspNetCore.Mvc;
using SoundWave.DTO.AuthDtos;

namespace SoundWave.WebUI.ViewComponents._AuthLayoutViewComponents
{
    public class _AuthLayoutRegisterFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(RegisterDto model)
        {
            return View(model);
        }
    }
}
