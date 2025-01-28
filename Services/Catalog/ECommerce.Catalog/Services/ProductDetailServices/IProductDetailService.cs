using ECommerce.Catalog.Dtos.ProductDetailDtos;

namespace ECommerce.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
        Task<GetByIdProductDetailDto> GetByProductIdProductDetailAsync(string id);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string id);
    }
}
