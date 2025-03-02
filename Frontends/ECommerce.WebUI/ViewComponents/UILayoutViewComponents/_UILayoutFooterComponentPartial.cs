using ECommerce.WebUI.Models;
using ECommerce.WebUI.Services.CatalogServices.AboutServices;
using ECommerce.WebUI.Services.CatalogServices.SocialMediaServices;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _UILayoutFooterComponentPartial : ViewComponent
    {
        private readonly IAboutService _aboutService;
        private readonly ISocialMediaService _socialMediaService;

        public _UILayoutFooterComponentPartial(IAboutService aboutService, ISocialMediaService socialMediaService)
        {
            _aboutService = aboutService;
            _socialMediaService = socialMediaService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var aboutValues = await _aboutService.GetAllAboutAsync();
            var socialMediaValues = await _socialMediaService.GetAllSocialMediaAsync();

            var model = new FooterViewModel
            {
                Abouts = aboutValues,
                SocialMedias = socialMediaValues
            };

            return View(model);
        }
    }
}
