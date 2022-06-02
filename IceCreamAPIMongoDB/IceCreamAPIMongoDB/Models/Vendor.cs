using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace IceCreamAPIMongoDB.Models
{
    public class Vendor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]


        public string? Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; } = null!;
        public string adress {get; set;} = null!;

        ////////Order details////
        [BsonElement("scoop")]
        public string[]? Scoop { get; set; }
        [BsonElement("cup")]
        public string? Cup { get; set; }
        [BsonElement("isSoft")]
        public string? IsSoft { get; set; }

    }
}