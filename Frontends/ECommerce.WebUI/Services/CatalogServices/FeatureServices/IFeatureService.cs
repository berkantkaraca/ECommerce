using ECommerce.DtoLayer.CatalogDtos.FeatureDtos;

namespace ECommerce.WebUI.Services.CatalogServices.FeatureServices
{
    public interface IFeatureService
    {
        Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
        Task<List<ResultFeatureDto>> GetAllFeatureAsync();
        Task<UpdateFeatureDto> GetByIdFeatureAsync(string id);
        Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
        Task DeleteFeatureAsync(string id);
    }
}
