using ECommerce.DtoLayer.CatalogDtos.BannerDtos;
using Newtonsoft.Json;

namespace ECommerce.WebUI.Services.CatalogServices.BannerServices
{
    public class BannerService : IBannerService
    {
        private readonly HttpClient _httpClient;
        public BannerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateBannerAsync(CreateBannerDto createBannerDto)
        {
            await _httpClient.PostAsJsonAsync<CreateBannerDto>("banners", createBannerDto);
        }
        public async Task DeleteBannerAsync(string id)
        {
            await _httpClient.DeleteAsync("banners?id=" + id);
        }
        public async Task<UpdateBannerDto> GetByIdBannerAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("banners/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateBannerDto>();
            return values;
        }
        public async Task<List<ResultBannerDto>> GetAllBannerAsync()
        {
            var responseMessage = await _httpClient.GetAsync("banners");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBannerDto>>(jsonData);
            return values;
        }
        public async Task UpdateBannerAsync(UpdateBannerDto updateBannerDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateBannerDto>("banners", updateBannerDto);
        }

        public Task BannerChangeStatusToTrue(string id)
        {
            throw new NotImplementedException();
        }

        public Task BannerChangeStatusToFalse(string id)
        {
            throw new NotImplementedException();
        }
    }
}
