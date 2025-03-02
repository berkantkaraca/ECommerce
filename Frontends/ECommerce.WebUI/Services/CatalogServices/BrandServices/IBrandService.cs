using ECommerce.DtoLayer.CatalogDtos.BrandDtos;

namespace ECommerce.WebUI.Services.CatalogServices.BrandServices
{
    public interface IBrandService
    {
        Task CreateBrandAsync(CreateBrandDto createBrandDto);
        Task<List<ResultBrandDto>> GetAllBrandAsync();
        Task<UpdateBrandDto> GetByIdBrandAsync(string id);
        Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
        Task DeleteBrandAsync(string id);
    }
}
