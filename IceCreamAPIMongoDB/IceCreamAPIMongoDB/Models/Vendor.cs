using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace IceCreamAPIMongoDB.Models
{
    [BsonIgnoreExtraElements]
    public class Vendor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("name")]
        public string? Name { get; set; } = null!;
        [BsonElement("address")]
        public string? Address {get; set;} = null!;

        ////////Order details////

        [BsonElement("available_toppings")]
        public string[]? Topping { get; set; }
        [BsonElement("available_containers")]
        public string[]? Cup { get; set; }
        [BsonElement("available_scoops")]
        public string[]? Scoop { get; set; }
        

    }
}