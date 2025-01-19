using ECommerce.DtoLayer.CatalogDtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();

            if (id == null)
            {
                var response = await client.GetAsync("https://localhost:7070/api/Products/ProductListWithCategory");
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
                    return View(values);
                }

            }
            else
            {
                var response = await client.GetAsync("https://localhost:7070/api/Products/ProductListWithCategoryByCategoryId?CategoryId=" + id);
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
                    return View(values);
                }
            }

            return View();
        }
    }
}
