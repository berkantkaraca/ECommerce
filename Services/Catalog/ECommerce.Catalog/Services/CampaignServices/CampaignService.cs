using AutoMapper;
using ECommerce.Catalog.Dtos.CampaignDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Services.CampaignServices;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;

namespace ECommerce.Catalog.Services.CampaignServices
{
    public class CampaignService : ICampaignService
    {
        private readonly IMongoCollection<Campaign> _campaignCollection;
        private readonly IMapper _mapper;

        public CampaignService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _campaignCollection = database.GetCollection<Campaign>(_databaseSettings.CampaignCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCampaignAsync(CreateCampaignDto createCampaignDto)
        {
            var value = _mapper.Map<Campaign>(createCampaignDto);
            await _campaignCollection.InsertOneAsync(value);
        }

        public async Task<List<ResultCampaignDto>> GetAllCampaignAsync()
        {
            var values = await _campaignCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultCampaignDto>>(values);
        }

        public async Task<GetByIdCampaignDto> GetByIdCampaignAsync(string id)
        {
            var values = await _campaignCollection.Find<Campaign>(x => x.CampaignId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCampaignDto>(values);
        }

        public async Task UpdateCampaignAsync(UpdateCampaignDto updateCampaignDto)
        {
            var values = _mapper.Map<Campaign>(updateCampaignDto);
            await _campaignCollection.FindOneAndReplaceAsync(x => x.CampaignId == updateCampaignDto.CampaignId, values);
        }

        public async Task DeleteCampaignAsync(string id)
        {
            await _campaignCollection.DeleteOneAsync(x => x.CampaignId == id);
        }
    }
}
