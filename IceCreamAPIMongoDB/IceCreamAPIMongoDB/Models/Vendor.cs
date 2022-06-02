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
        public string Adress {get; set;} = null!;
    }
}