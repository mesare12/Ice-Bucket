using MongoDB.Bson.Serialization.Attributes;


namespace IceCreamAPIMongoDB.Models
{
    public class Cup
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]

        public string? Id { get; set; }
        [BsonElement("material")]
        public string? Material { get; set; }
        [BsonElement("size")]
        public string? Size { get; set; }
        [BsonElement("price")]
        public int? Price { get; set; }
    }
}
