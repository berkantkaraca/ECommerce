using AutoMapper;
using ECommerce.Catalog.Dtos.SocialMediaDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Services.SocialMediaServices;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;

namespace ECommerce.Catalog.Services.SocialMediaServices
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly IMongoCollection<SocialMedia> _socialMediaCollection;
        private readonly IMapper _mapper;

        public SocialMediaService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _socialMediaCollection = database.GetCollection<SocialMedia>(_databaseSettings.SocialMediaCollectionName);
            _mapper = mapper;
        }

        public async Task CreateSocialMediaAsync(CreateSocialMediaDto createSocialMediaDto)
        {
            var value = _mapper.Map<SocialMedia>(createSocialMediaDto);
            await _socialMediaCollection.InsertOneAsync(value);
        }

        public async Task<List<ResultSocialMediaDto>> GetAllSocialMediaAsync()
        {
            var values = await _socialMediaCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSocialMediaDto>>(values);
        }

        public async Task<GetByIdSocialMediaDto> GetByIdSocialMediaAsync(string id)
        {
            var values = await _socialMediaCollection.Find<SocialMedia>(x => x.SocialMediaId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdSocialMediaDto>(values);

        }

        public async Task UpdateSocialMediaAsync(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var values = _mapper.Map<SocialMedia>(updateSocialMediaDto);
            await _socialMediaCollection.FindOneAndReplaceAsync(x => x.SocialMediaId == updateSocialMediaDto.SocialMediaId, values);
        }

        public async Task DeleteSocialMediaAsync(string id)
        {
            await _socialMediaCollection.DeleteOneAsync(x => x.SocialMediaId == id);
        }
    }
}
