using ECommerce.Catalog.Dtos.BannerDtos;

namespace ECommerce.Catalog.Services.BannerServices
{
    public interface IBannerService
    {
        Task CreateBannerAsync(CreateBannerDto createBannerDto);
        Task<List<ResultBannerDto>> GetAllBannerAsync();
        Task<GetByIdBannerDto> GetBannerByIdAsync(string id);
        Task UpdateBannerAsync(UpdateBannerDto updateBannerDto);
        Task DeleteBannerAsync(string id);
        Task BannerChangeStatusToTrue(string id);
        Task BannerChangeStatusToFalse(string id);
    }
}
