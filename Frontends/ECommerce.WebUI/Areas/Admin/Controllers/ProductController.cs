using ECommerce.DtoLayer.CatalogDtos.CategoryDtos;
using ECommerce.DtoLayer.CatalogDtos.ProductDetailDtos;
using ECommerce.DtoLayer.CatalogDtos.ProductDtos;
using ECommerce.DtoLayer.CatalogDtos.ProductImageDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";
            ViewBag.v4 = "Ürün İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7070/api/Products");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        [Route("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";
            ViewBag.v4 = "Ürün İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7070/api/Products/ProductListWithCategory");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Yeni Ürün Girişi";
            ViewBag.v4 = "Ürün Ekleme";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7070/api/Categories");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            List<SelectListItem> categories = (from x in values
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId
                                               }).ToList();
            ViewBag.Categories = categories;

            return View();
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7070/api/Products", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });

            }
            return View();
        }

        [HttpGet]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürün";
            ViewBag.v3 = "Ürün Güncelleme";
            ViewBag.v4 = "Ürün Güncelleme";

            var client = _httpClientFactory.CreateClient();
            var response2 = await client.GetAsync("https://localhost:7070/api/Categories");
            var jsonData2 = await response2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData2);
            List<SelectListItem> categories = (from x in values2
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId
                                               }).ToList();
            ViewBag.Categories = categories;

            var response = await client.GetAsync("https://localhost:7070/api/Products/" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7070/api/Products", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync("https://localhost:7070/api/Products?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("ProductImages/{id}")]
        public async Task<IActionResult> ProductImages(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürün";
            ViewBag.v3 = "Ürün Görsel Güncelleme";
            ViewBag.v4 = "Ürün Görsel Güncelleme";

            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync("https://localhost:7070/api/ProductImages/ProductImagesByProductId?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductImageDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("ProductImages/{id}")]
        public async Task<IActionResult> ProductImages(UpdateProductImageDto updateProductImageDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductImageDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7070/api/ProductImages", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateProductDetail/{id}")]
        public async Task<IActionResult> UpdateProductDetail(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürün Deatay";
            ViewBag.v3 = "Ürün Deatay Güncelleme";
            ViewBag.v4 = "Ürün Deatay Güncelleme";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7070/api/ProductDetails/GetProductDetailByProductId?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateProductDetail/{id}")]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDetailDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7070/api/ProductDetails", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }
            return View();
        }
    }
}
