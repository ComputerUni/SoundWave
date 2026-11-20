using Microsoft.AspNetCore.Mvc;
using SoundWave.DTO.SelectPlanDtos;

namespace SoundWave.WebUI.ViewComponents._AuthLayoutViewComponents
{
    public class _AuthLayoutSelectPlanFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(SelectPlanDto model)
        {
            return View(model);
        }
    }
}
