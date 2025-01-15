using AutoMapper;
using ECommerce.Catalog.Dtos.BannerDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;

namespace ECommerce.Catalog.Services.BannerServices
{
    public class BannerService : IBannerService
    {
        private readonly IMongoCollection<Banner> _BannerCollection;
        private readonly IMapper _mapper;

        public BannerService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _BannerCollection = database.GetCollection<Banner>(_databaseSettings.BannerCollectionName);
            _mapper = mapper;
        }
        public async Task CreateBannerAsync(CreateBannerDto createBannerDto)
        {
            var value = _mapper.Map<Banner>(createBannerDto);
            await _BannerCollection.InsertOneAsync(value);
        }
        public async Task DeleteBannerAsync(string id)
        {
            await _BannerCollection.DeleteOneAsync(x => x.BannerId == id);
        }

        public Task BannerChangeStatusToFalse(string id)
        {
            throw new NotImplementedException();
        }

        public Task BannerChangeStatusToTrue(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultBannerDto>> GetAllBannerAsync()
        {
            var values = await _BannerCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultBannerDto>>(values);
        }

        public async Task<GetByIdBannerDto> GetByIdBannerAsync(string id)
        {
            var values = await _BannerCollection.Find<Banner>(x => x.BannerId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdBannerDto>(values);
        }

        public async Task UpdateBannerAsync(UpdateBannerDto updateBannerDto)
        {
            var values = _mapper.Map<Banner>(updateBannerDto);
            await _BannerCollection.FindOneAndReplaceAsync(x => x.BannerId == updateBannerDto.BannerId, values);
        }
    }
}
