using Microsoft.AspNetCore.Mvc;

namespace SoundWave.WebUI.Areas.Admin.Controllers
{
    public class ArtistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
