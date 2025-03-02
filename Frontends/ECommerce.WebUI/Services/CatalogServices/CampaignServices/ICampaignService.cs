using ECommerce.DtoLayer.CatalogDtos.CampaignDtos;

namespace ECommerce.WebUI.Services.CatalogServices.CampaignServices
{
    public interface ICampaignService
    {
        Task CreateCampaignAsync(CreateCampaignDto createCampaignDto);
        Task<List<ResultCampaignDto>> GetAllCampaignAsync();
        Task<UpdateCampaignDto> GetByIdCampaignAsync(string id);
        Task UpdateCampaignAsync(UpdateCampaignDto updateCampaignDto);
        Task DeleteCampaignAsync(string id);
    }
}
