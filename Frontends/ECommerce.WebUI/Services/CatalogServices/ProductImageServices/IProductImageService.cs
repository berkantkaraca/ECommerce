using ECommerce.DtoLayer.CatalogDtos.ProductImageDtos;

namespace ECommerce.WebUI.Services.CatalogServices.ProductImageServices
{
    public interface IProductImageService
    {
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();
        Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);
        Task<GetByIdProductImageDto> GetByProductIdProductImageAsync(string id);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string id);
    }
}
