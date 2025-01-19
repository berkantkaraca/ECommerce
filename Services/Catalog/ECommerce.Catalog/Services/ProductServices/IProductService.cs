using ECommerce.Catalog.Dtos.ProductDtos;

namespace ECommerce.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<GetByIdProductDto> GetProductByIdAsync(string id);
        Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryAsync();
        Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string CategoryId);

        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
    }
}
