using ECommerce.DtoLayer.CatalogDtos.BannerDtos;
using ECommerce.WebUI.Services.CatalogServices.BannerServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Banner")]
    public class BannerController : Controller
    {
        private readonly IBannerService _bannerService;
        public BannerController(IBannerService BannerService)
        {
            _bannerService = BannerService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Öne Çıkan";
            ViewBag.v3 = "Banner";
            ViewBag.v4 = "Banner İşlemleri";

            var values = await _bannerService.GetAllBannerAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateBanner")]
        public IActionResult CreateBanner()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Öne Çıkan";
            ViewBag.v3 = "Banner Ekleme";
            ViewBag.v4 = "Banner Ekleme";
            return View();
        }

        [HttpPost]
        [Route("CreateBanner")]
        public async Task<IActionResult> CreateBanner(CreateBannerDto createBannerDto)
        {
            await _bannerService.CreateBannerAsync(createBannerDto);
            return RedirectToAction("Index", "Banner", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateBanner/{id}")]
        public async Task<IActionResult> UpdateBanner(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Öne Çıkan";
            ViewBag.v3 = "Banner Güncelleme";
            ViewBag.v4 = "Banner Güncelleme";

            var values = await _bannerService.GetByIdBannerAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateBanner/{id}")]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto updateBannerDto)
        {
            await _bannerService.UpdateBannerAsync(updateBannerDto);
            return RedirectToAction("Index", "Banner", new { area = "Admin" });
        }

        [Route("DeleteBanner/{id}")]
        public async Task<IActionResult> DeleteBanner(string id)
        {
            await _bannerService.DeleteBannerAsync(id);
            return RedirectToAction("Index", "Banner", new { area = "Admin" });
        }
    }
}
