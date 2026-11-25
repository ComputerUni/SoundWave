using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoundWave.WebUI.Constants;

namespace SoundWave.WebUI.Areas.Admin.Controllers
{
    [Area(AppRoles.Admin)]
    [Authorize(Roles = AppRoles.Admin)]
    public abstract class BaseAdminController : Controller
    {

    }
}
