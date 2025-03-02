using ECommerce.DtoLayer.CatalogDtos.SocialMediaDtos;
using Newtonsoft.Json;

namespace ECommerce.WebUI.Services.CatalogServices.SocialMediaServices
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly HttpClient _httpClient;
        public SocialMediaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateSocialMediaAsync(CreateSocialMediaDto createSocialMediaDto)
        {
            await _httpClient.PostAsJsonAsync<CreateSocialMediaDto>("socialmedias", createSocialMediaDto);
        }

        public async Task<List<ResultSocialMediaDto>> GetAllSocialMediaAsync()
        {
            var responseMessage = await _httpClient.GetAsync("socialmedias");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
            return values;
        }

        public async Task<UpdateSocialMediaDto> GetByIdSocialMediaAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("socialmedias/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateSocialMediaDto>();
            return values;
        }

        public async Task UpdateSocialMediaAsync(UpdateSocialMediaDto updateSocialMediaDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateSocialMediaDto>("socialmedias", updateSocialMediaDto);
        }

        public async Task DeleteSocialMediaAsync(string id)
        {
            await _httpClient.DeleteAsync("socialmedias?id=" + id);
        }
    }
}
