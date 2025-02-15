using ECommerce.Catalog.Dtos.BannerDtos;
using ECommerce.Catalog.Services.BannerServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly IBannerService _bannerService;

        public BannersController(IBannerService BannerService)
        {
            _bannerService = BannerService;
        }

        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var values = await _bannerService.GetAllBannerAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBannerById(string id)
        {
            var values = await _bannerService.GetByIdBannerAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto createBannerDto)
        {
            await _bannerService.CreateBannerAsync(createBannerDto);
            return Ok("Banner eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto updateBannerDto)
        {
            await _bannerService.UpdateBannerAsync(updateBannerDto);
            return Ok("Banner güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBanner(string id)
        {
            await _bannerService.DeleteBannerAsync(id);
            return Ok("Banner silindi.");
        }
    }
}
