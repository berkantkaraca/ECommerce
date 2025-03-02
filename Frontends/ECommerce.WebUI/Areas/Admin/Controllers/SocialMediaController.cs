using ECommerce.DtoLayer.CatalogDtos.SocialMediaDtos;
using ECommerce.WebUI.Services.CatalogServices.SocialMediaServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/SocialMedia")]
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaService _socialMediaService;
        public SocialMediaController(ISocialMediaService SocialMediaService)
        {
            _socialMediaService = SocialMediaService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Sosyal Medya";
            ViewBag.v3 = "Sosyal Medya Listesi";
            ViewBag.v4 = "Sosyal Medya İşlemleri";

            var values = await _socialMediaService.GetAllSocialMediaAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateSocialMedia")]
        public IActionResult CreateSocialMedia()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Sosyal Medya";
            ViewBag.v3 = "Yeni Sosyal Medya Girişi";
            ViewBag.v4 = "Sosyal Medya Ekleme";
            return View();
        }

        [HttpPost]
        [Route("CreateSocialMedia")]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            await _socialMediaService.CreateSocialMediaAsync(createSocialMediaDto);
            return RedirectToAction("Index", "SocialMedia", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateSocialMedia/{id}")]
        public async Task<IActionResult> UpdateSocialMedia(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Sosyal Medya";
            ViewBag.v3 = "Sosyal Medya Güncelleme";
            ViewBag.v4 = "Sosyal Medya Güncelleme";

            var values = await _socialMediaService.GetByIdSocialMediaAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateSocialMedia/{id}")]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            await _socialMediaService.UpdateSocialMediaAsync(updateSocialMediaDto);
            return RedirectToAction("Index", "SocialMedia", new { area = "Admin" });
        }

        [Route("DeleteSocialMedia/{id}")]
        public async Task<IActionResult> DeleteSocialMedia(string id)
        {
            await _socialMediaService.DeleteSocialMediaAsync(id);
            return RedirectToAction("Index", "SocialMedia", new { area = "Admin" });
        }
    }
}
