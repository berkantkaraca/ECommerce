using ECommerce.DtoLayer.CatalogDtos.ProductDtos;
using ECommerce.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace ECommerce.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultSuggestProductComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _DefaultSuggestProductComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetProductsWithCategoryAsync();
            return View(values);
        }
    }
}
