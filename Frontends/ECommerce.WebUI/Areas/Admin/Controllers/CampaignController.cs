using ECommerce.DtoLayer.CatalogDtos.CampaignDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Campaign")]
    public class CampaignController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CampaignController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kampanyalar";
            ViewBag.v3 = "Kampanya Listesi";
            ViewBag.v4 = "Kampanya İşlemleri";

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
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCampaignDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7070/api/Campaigns", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Campaign", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateCampaign/{id}")]
        public async Task<IActionResult> UpdateCampaign(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kampanya";
            ViewBag.v3 = "Kampanya Güncelleme";
            ViewBag.v4 = "Kampanya Güncelleme";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7070/api/Campaigns/" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCampaignDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateCampaign/{id}")]
        public async Task<IActionResult> UpdateCampaign(UpdateCampaignDto updateCampaignDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCampaignDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7070/api/Campaigns", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Campaign", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteCampaign/{id}")]
        public async Task<IActionResult> DeleteCampaign(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync("https://localhost:7070/api/Campaigns?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Campaign", new { area = "Admin" });
            }
            return View();
        }
    }
}
