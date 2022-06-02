using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace IceCreamAPIMongoDB.Models
{
    public class Vendor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]


        public string? Id { get; set; }
        public string Name { get; set; } = null!;
        //public string adress {get; set;} = null!;
    }
}