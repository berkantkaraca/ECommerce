using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Areas.User.Controllers
{
    public class UserLayoutController : Controller
    {
        [Area("User")]
        public IActionResult _UserLayout()
        {
            return View();
        }
    }
}
