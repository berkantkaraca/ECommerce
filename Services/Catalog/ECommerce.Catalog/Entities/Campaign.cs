using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ECommerce.Catalog.Entities
{
    public class Campaign
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CampaignId { get; set; }
        public string Title { get; set; }
        public string ColorfulText { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
