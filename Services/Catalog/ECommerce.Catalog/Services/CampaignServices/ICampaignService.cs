using ECommerce.Catalog.Dtos.CampaignDtos;

namespace ECommerce.Catalog.Services.CampaignServices
{
    public interface ICampaignService
    {
        Task CreateCampaignAsync(CreateCampaignDto createCampaignDto);
        Task<List<ResultCampaignDto>> GetAllCampaignAsync();
        Task<GetByIdCampaignDto> GetByIdCampaignAsync(string id);
        Task UpdateCampaignAsync(UpdateCampaignDto updateCampaignDto);
        Task DeleteCampaignAsync(string id);
    }
}
