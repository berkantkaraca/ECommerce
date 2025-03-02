using ECommerce.DtoLayer.CatalogDtos.ProductDtos;

namespace ECommerce.WebUI.Services.CatalogServices.ProductServices
{
    public interface IProductService
    {
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync();
        Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCatetegoryIdAsync(string CategoryId);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task<UpdateProductDto> GetByIdProductAsync(string id);
        Task DeleteProductAsync(string id);
    }
}
