using MongoDB.Bson.Serialization.Attributes;

namespace IceCreamAPIMongoDB.Models
{
    [BsonIgnoreExtraElements] //Required for additional arrays in class
    public class ScoopItem
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]


        public string? Id { get; set; }
        
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsSoft { get; set; }
        public int Quantity { get; set; }
    }
}
