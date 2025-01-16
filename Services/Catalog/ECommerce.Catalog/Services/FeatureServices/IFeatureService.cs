using ECommerce.Catalog.Dtos.FeatureDtos;

namespace ECommerce.Catalog.Services.FeatureServices
{
    public interface IFeatureService
    {
        Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
        Task<List<ResultFeatureDto>> GetAllFeatureAsync();
        Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id);
        Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
        Task DeleteFeatureAsync(string id);
    }
}
