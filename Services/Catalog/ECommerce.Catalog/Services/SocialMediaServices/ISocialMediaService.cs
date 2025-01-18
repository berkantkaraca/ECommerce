using ECommerce.Catalog.Dtos.SocialMediaDtos;

namespace ECommerce.Catalog.Services.SocialMediaServices
{
    public interface ISocialMediaService
    {
        Task CreateSocialMediaAsync(CreateSocialMediaDto createSocialMediaDto);
        Task<List<ResultSocialMediaDto>> GetAllSocialMediaAsync();
        Task<GetByIdSocialMediaDto> GetByIdSocialMediaAsync(string id);
        Task UpdateSocialMediaAsync(UpdateSocialMediaDto updateSocialMediaDto);
        Task DeleteSocialMediaAsync(string id);
    }
}
