using ECommerce.DtoLayer.CatalogDtos.AboutDtos;
using ECommerce.DtoLayer.CatalogDtos.SocialMediaDtos;
using ECommerce.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _UILayoutFooterComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UILayoutFooterComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var aboutsResponse = await client.GetAsync("https://localhost:7070/api/Abouts");
            var socialMediasResponse = await client.GetAsync("https://localhost:7070/api/SocialMedias");


            if (aboutsResponse.IsSuccessStatusCode && socialMediasResponse.IsSuccessStatusCode)
            {
                var aboutsJson = await aboutsResponse.Content.ReadAsStringAsync();
                var abouts = JsonConvert.DeserializeObject<List<ResultAboutDto>>(aboutsJson);

                var socialMediasJson = await socialMediasResponse.Content.ReadAsStringAsync();
                var socialMedias = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(socialMediasJson);

                var model = new FooterViewModel
                {
                    Abouts = abouts,
                    SocialMedias = socialMedias
                };

                return View(model);
            }

            return View();
        }
    }
}
