using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json;


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
        public List<Dictionary<string, object>> Toppings { get; set; } = null!;
        [BsonElement("available_containers")]
        public List<Dictionary<string, object>> Cup { get; set; } = null!;
        [BsonElement("available_scoops")]
        public List<Dictionary<string, object>> Scoop { get; set; } = null!;


    }
}