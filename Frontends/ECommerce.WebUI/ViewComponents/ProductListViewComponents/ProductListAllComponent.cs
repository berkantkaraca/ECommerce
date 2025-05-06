using ECommerce.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.WebUI.ViewComponents.ProductListViewComponents
{
    public class ProductListAllComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IProductService _productService;


        public ProductListAllComponent(IHttpClientFactory httpClientFactory, IProductService productService)
        {
            _httpClientFactory = httpClientFactory;
            _productService = productService;
        }

        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var response = await client.GetAsync("http://localhost:7070/api/Products/ProductListWithCategory");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var jsonData = await response.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
        //        return View(values);
        //    }
        //    return View(new List<ResultProductWithCategoryDto>());
        //}

  

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productService.GetAllProductAsync();
            return View(values);
        }
    }
}
