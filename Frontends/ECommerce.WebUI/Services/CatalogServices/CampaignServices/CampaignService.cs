using ECommerce.DtoLayer.CatalogDtos.CampaignDtos;
using Newtonsoft.Json;

namespace ECommerce.WebUI.Services.CatalogServices.CampaignServices
{
    public class CampaignService : ICampaignService
    {
        private readonly HttpClient _httpClient;
        public CampaignService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCampaignAsync(CreateCampaignDto createCampaignDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCampaignDto>("campaigns", createCampaignDto);
        }

        public async Task<List<ResultCampaignDto>> GetAllCampaignAsync()
        {
            var responseMessage = await _httpClient.GetAsync("campaigns");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCampaignDto>>(jsonData);
            return values;
        }

        public async Task<UpdateCampaignDto> GetByIdCampaignAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("campaigns/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateCampaignDto>();
            return values;
        }

        public async Task UpdateCampaignAsync(UpdateCampaignDto updateCampaignDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCampaignDto>("campaigns", updateCampaignDto);
        }

        public async Task DeleteCampaignAsync(string id)
        {
            await _httpClient.DeleteAsync("categories?id=" + id);
        }
    }
}
