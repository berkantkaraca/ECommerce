using ECommerce.WebUI.Services.CatalogServices.BannerServices;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultBannerComponentPartial : ViewComponent
    {
        private readonly IBannerService _bannerService;

        public _DefaultBannerComponentPartial(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _bannerService.GetAllBannerAsync();
            return View(values);
        }
    }
}
