﻿using ECommerce.DtoLayer.CatalogDtos.CategoryDtos;
using ECommerce.DtoLayer.CatalogDtos.ProductDetailDtos;
using ECommerce.DtoLayer.CatalogDtos.ProductDtos;
using ECommerce.DtoLayer.CatalogDtos.ProductImageDtos;
using ECommerce.WebUI.Services.CatalogServices.CategoryServices;
using ECommerce.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";
            ViewBag.v4 = "Ürün İşlemleri";

            var values = await _productService.GetAllProductAsync();
            return View(values);
        }

        [HttpGet]
        [Route("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";
            ViewBag.v4 = "Ürün İşlemleri";

            //var client = _httpClientFactory.CreateClient();
            //var response = await client.GetAsync("https://localhost:7070/api/Products/ProductListWithCategory");

            //if (response.IsSuccessStatusCode)
            //{
            //    var jsonData = await response.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            //    return View(values);
            //}
            var values = await _productService.GetProductsWithCategoryAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Yeni Ürün Girişi";
            ViewBag.v4 = "Ürün Ekleme";

            var values = await _categoryService.GetAllCategoryAsync();
            List<SelectListItem> categoryValues = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId
                                                   }).ToList();
            ViewBag.Categories = categoryValues;
            return View();
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürün";
            ViewBag.v3 = "Ürün Güncelleme";
            ViewBag.v4 = "Ürün Güncelleme";

            var values = await _categoryService.GetAllCategoryAsync();
            List<SelectListItem> categoryValues = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId
                                                   }).ToList();
            ViewBag.Categories = categoryValues;

            var productValues = await _productService.GetByIdProductAsync(id);
            return View(productValues);
        }

        [HttpPost]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        //[HttpGet]
        //[Route("ProductImages/{id}")]
        //public async Task<IActionResult> ProductImages(string id)
        //{
        //    ViewBag.v1 = "Ana Sayfa";
        //    ViewBag.v2 = "Ürün";
        //    ViewBag.v3 = "Ürün Görsel Güncelleme";
        //    ViewBag.v4 = "Ürün Görsel Güncelleme";

        //    var client = _httpClientFactory.CreateClient();

        //    var response = await client.GetAsync("https://localhost:7070/api/ProductImages/ProductImagesByProductId?id=" + id);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var jsonData = await response.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<UpdateProductImageDto>(jsonData);
        //        return View(values);
        //    }
        //    return View();
        //}

        //[HttpPost]
        //[Route("ProductImages/{id}")]
        //public async Task<IActionResult> ProductImages(UpdateProductImageDto updateProductImageDto)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var jsonData = JsonConvert.SerializeObject(updateProductImageDto);
        //    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //    var response = await client.PutAsync("https://localhost:7070/api/ProductImages", content);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
        //    }
        //    return View();
        //}

        //[HttpGet]
        //[Route("UpdateProductDetail/{id}")]
        //public async Task<IActionResult> UpdateProductDetail(string id)
        //{
        //    ViewBag.v1 = "Ana Sayfa";
        //    ViewBag.v2 = "Ürün Deatay";
        //    ViewBag.v3 = "Ürün Deatay Güncelleme";
        //    ViewBag.v4 = "Ürün Deatay Güncelleme";

        //    var client = _httpClientFactory.CreateClient();
        //    var response = await client.GetAsync("https://localhost:7070/api/ProductDetails/GetProductDetailByProductId?id=" + id);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var jsonData = await response.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData);
        //        return View(values);
        //    }
        //    return View();
        //}

        //[HttpPost]
        //[Route("UpdateProductDetail/{id}")]
        //public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var jsonData = JsonConvert.SerializeObject(updateProductDetailDto);
        //    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //    var response = await client.PutAsync("https://localhost:7070/api/ProductDetails", content);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
        //    }
        //    return View();
        //}
    }
}
