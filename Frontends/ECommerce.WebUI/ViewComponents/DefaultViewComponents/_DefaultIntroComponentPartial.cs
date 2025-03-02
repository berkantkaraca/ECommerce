using ECommerce.WebUI.Services.CatalogServices.CampaignServices;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultIntroComponentPartial : ViewComponent
    {
        private readonly ICampaignService _campaignService;

        public _DefaultIntroComponentPartial(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _campaignService.GetAllCampaignAsync();
            return View(values);
        }
    }
}
