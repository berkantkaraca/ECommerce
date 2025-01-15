using ECommerce.DtoLayer.CatalogDtos.CampaignDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultIntroComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultIntroComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7070/api/Campaigns");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCampaignDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
