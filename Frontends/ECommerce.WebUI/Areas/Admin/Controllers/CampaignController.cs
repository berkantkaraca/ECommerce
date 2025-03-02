using ECommerce.DtoLayer.CatalogDtos.CampaignDtos;
using ECommerce.WebUI.Services.CatalogServices.CampaignServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Campaign")]
    public class CampaignController : Controller
    {
        private readonly ICampaignService _campaignService;

        public CampaignController(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kampanyalar";
            ViewBag.v3 = "Kampanya Listesi";
            ViewBag.v4 = "Kampanya İşlemleri";

            var values = await _campaignService.GetAllCampaignAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateCampaign")]
        public IActionResult CreateCampaign()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kampanyalar";
            ViewBag.v3 = "Yeni Kampanya Girişi";
            ViewBag.v4 = "Kampanya Ekleme";
            return View();
        }

        [HttpPost]
        [Route("CreateCampaign")]
        public async Task<IActionResult> CreateCampaign(CreateCampaignDto createCampaignDto)
        {
            await _campaignService.CreateCampaignAsync(createCampaignDto);
            return RedirectToAction("Index", "Campaign", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateCampaign/{id}")]
        public async Task<IActionResult> UpdateCampaign(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kampanya";
            ViewBag.v3 = "Kampanya Güncelleme";
            ViewBag.v4 = "Kampanya Güncelleme";

            var values = await _campaignService.GetByIdCampaignAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateCampaign/{id}")]
        public async Task<IActionResult> UpdateCampaign(UpdateCampaignDto updateCampaignDto)
        {
            await _campaignService.UpdateCampaignAsync(updateCampaignDto);
            return RedirectToAction("Index", "Campaign", new { area = "Admin" });
        }

        [Route("DeleteCampaign/{id}")]
        public async Task<IActionResult> DeleteCampaign(string id)
        {
            await _campaignService.DeleteCampaignAsync(id);
            return RedirectToAction("Index", "Campaign", new { area = "Admin" });
        }
    }
}
