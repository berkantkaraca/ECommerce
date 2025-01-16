using ECommerce.Catalog.Dtos.BrandDtos;

namespace ECommerce.Catalog.Services.BrandServices
{
    public interface IBrandService
    {
        Task CreateBrandAsync(CreateBrandDto createBrandDto);
        Task<List<ResultBrandDto>> GetAllBrandAsync();
        Task<GetByIdBrandDto> GetByIdBrandAsync(string id);
        Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
        Task DeleteBrandAsync(string id);
    }
}
