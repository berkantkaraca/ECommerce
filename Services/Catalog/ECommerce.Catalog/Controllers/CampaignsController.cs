using ECommerce.Catalog.Dtos.CampaignDtos;
using ECommerce.Catalog.Services.CampaignServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignsController : ControllerBase
    {
        private readonly ICampaignService _campaignService;

        public CampaignsController(ICampaignService CampaignService)
        {
            _campaignService = CampaignService;
        }

        [HttpGet]
        public async Task<IActionResult> CampaignList()
        {
            var values = await _campaignService.GetAllCampaignAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCampaignById(string id)
        {
            var values = await _campaignService.GetByIdCampaignAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCampaign(CreateCampaignDto createCampaignDto)
        {
            await _campaignService.CreateCampaignAsync(createCampaignDto);
            return Ok("Kampanya eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCampaign(UpdateCampaignDto updateCampaignDto)
        {
            await _campaignService.UpdateCampaignAsync(updateCampaignDto);
            return Ok("Kampanya güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCampaign(string id)
        {
            await _campaignService.DeleteCampaignAsync(id);
            return Ok("Kampanya silindi.");
        }
    }
}
