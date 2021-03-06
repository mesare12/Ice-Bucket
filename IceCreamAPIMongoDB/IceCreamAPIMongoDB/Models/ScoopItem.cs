using MongoDB.Bson.Serialization.Attributes;

namespace IceCreamAPIMongoDB.Models
{
    [BsonIgnoreExtraElements] //Required for additional arrays in class
    public class ScoopItem
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]


        public string? Id { get; set; }
        [BsonElement("flavor")]
        public string Scoop { get; set; } = null!;
        [BsonElement("soft")]
        public bool Soft { get; set; }
        [BsonElement("price")]
        public int? Price { get; set; }
    }
}
