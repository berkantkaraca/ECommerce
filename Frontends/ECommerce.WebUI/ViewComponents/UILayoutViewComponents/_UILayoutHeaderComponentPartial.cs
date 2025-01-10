using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _UILayoutHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
