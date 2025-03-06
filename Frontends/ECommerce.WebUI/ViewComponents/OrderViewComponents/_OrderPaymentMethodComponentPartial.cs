using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderPaymentMethodComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
