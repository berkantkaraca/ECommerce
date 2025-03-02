using ECommerce.DtoLayer.CatalogDtos.BannerDtos;

namespace ECommerce.WebUI.Services.CatalogServices.BannerServices
{
    public interface IBannerService
    {
        Task CreateBannerAsync(CreateBannerDto createBannerDto);
        Task<List<ResultBannerDto>> GetAllBannerAsync();
        Task<UpdateBannerDto> GetByIdBannerAsync(string id);
        Task UpdateBannerAsync(UpdateBannerDto updateBannerDto);
        Task DeleteBannerAsync(string id);
        Task BannerChangeStatusToTrue(string id);
        Task BannerChangeStatusToFalse(string id);
    }
}
