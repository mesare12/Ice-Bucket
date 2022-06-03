using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace IceCreamAPIMongoDB.Models
{
    public class Accessory
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string? Id { get; set; }
        [BsonElement("accessory")]
        public string? Topping { get; set; }
        [BsonElement("type")]
        public string? Type { get; set; }
        [BsonElement("price")]
        public int? Price { get; set; }
    }
}
