using ECommerce.Catalog.Dtos.SocialMediaDtos;
using ECommerce.Catalog.Services.SocialMediaServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;

        public SocialMediasController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        [HttpGet]
        public async Task<IActionResult> SocialMediaList()
        {
            var values = await _socialMediaService.GetAllSocialMediaAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMediaById(string id)
        {
            var values = await _socialMediaService.GetByIdSocialMediaAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            await _socialMediaService.CreateSocialMediaAsync(createSocialMediaDto);
            return Ok("Sosyal medya eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSocialMedia(string id)
        {
            await _socialMediaService.DeleteSocialMediaAsync(id);
            return Ok("Sosyal medya silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            await _socialMediaService.UpdateSocialMediaAsync(updateSocialMediaDto);
            return Ok("Sosyal medya güncellendi.");
        }
    }
}
