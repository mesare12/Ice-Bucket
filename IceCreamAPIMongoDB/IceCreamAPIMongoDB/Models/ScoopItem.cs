using MongoDB.Bson.Serialization.Attributes;

namespace IceCreamAPIMongoDB.Models
{
    [BsonIgnoreExtraElements] //Required for additional arrays in class
    public class ScoopItem
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]


        public string? Id { get; set; }
        public string _name { get; set; } = null!;
        public bool _isSoft { get; set; }
    }
}
