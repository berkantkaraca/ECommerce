﻿using ECommerce.DtoLayer.CatalogDtos.BrandDtos;
using ECommerce.WebUI.Services.CatalogServices.BrandServices;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Brand")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Marka";
            ViewBag.v3 = "Marka Listesi";
            ViewBag.v4 = "Marka İşlemleri";

            var values = await _brandService.GetAllBrandAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateBrand")]
        public IActionResult CreateBrand()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Marka";
            ViewBag.v3 = "Yeni Marka Girişi";
            ViewBag.v4 = "Marka Ekleme";
            return View();
        }

        [HttpPost]
        [Route("CreateBrand")]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            await _brandService.CreateBrandAsync(createBrandDto);
            return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateBrand/{id}")]
        public async Task<IActionResult> UpdateBrand(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Marka";
            ViewBag.v3 = "Marka Güncelleme";
            ViewBag.v4 = "Marka Güncelleme";

            var values = await _brandService.GetByIdBrandAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateBrand/{id}")]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            await _brandService.UpdateBrandAsync(updateBrandDto);
            return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }

        [Route("DeleteBrand/{id}")]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            await _brandService.DeleteBrandAsync(id);
            return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }
    }
}
