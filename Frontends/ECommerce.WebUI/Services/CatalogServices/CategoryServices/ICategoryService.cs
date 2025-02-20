using ECommerce.DtoLayer.CatalogDtos.CategoryDtos;

namespace ECommerce.WebUI.Services.CatalogServices.CategoryServices
{
    public interface ICategoryService
    {
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string id);
    }
}
