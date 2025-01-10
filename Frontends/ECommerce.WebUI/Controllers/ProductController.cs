using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductList()
        {
            return View();
        }

        public IActionResult ProductDetail()
        {
            return View();
        }
    }
}
