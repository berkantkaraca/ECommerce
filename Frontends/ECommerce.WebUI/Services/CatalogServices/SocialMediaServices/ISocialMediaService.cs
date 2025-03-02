using ECommerce.DtoLayer.CatalogDtos.SocialMediaDtos;

namespace ECommerce.WebUI.Services.CatalogServices.SocialMediaServices
{
    public interface ISocialMediaService
    {
        Task CreateSocialMediaAsync(CreateSocialMediaDto createSocialMediaDto);
        Task<List<ResultSocialMediaDto>> GetAllSocialMediaAsync();
        Task<UpdateSocialMediaDto> GetByIdSocialMediaAsync(string id);
        Task UpdateSocialMediaAsync(UpdateSocialMediaDto updateSocialMediaDto);
        Task DeleteSocialMediaAsync(string id);
    }
}
