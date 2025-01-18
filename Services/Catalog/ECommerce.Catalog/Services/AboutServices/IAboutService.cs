using ECommerce.Catalog.Dtos.AboutDtos;

namespace ECommerce.Catalog.Services.AboutServices
{
    public interface IAboutService
    {
        Task CreateAboutAsync(CreateAboutDto createAboutDto);
        Task<List<ResultAboutDto>> GetAllAboutAsync();
        Task<GetByIdAboutDto> GetByIdAboutAsync(string id);
        Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        Task DeleteAboutAsync(string id);
    }
}
