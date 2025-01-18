using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ECommerce.Catalog.Entities
{
    public class SocialMedia
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SocialMediaId { get; set; }
        public string SocialMediaName { get; set; }
        public string SocialMediaLink { get; set; }
        public string SocialMediaIcon { get; set; }
    }
}
