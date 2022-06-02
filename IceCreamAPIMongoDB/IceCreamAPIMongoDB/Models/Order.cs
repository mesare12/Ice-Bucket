using MongoDB.Bson.Serialization.Attributes;

namespace IceCreamAPIMongoDB.Models
{
    [BsonIgnoreExtraElements] //Required for additional arrays in class
    public class Order
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        
        public string? Id { get; set; }

        public string? Cup { get; set; }

        public List<string>? Scoops { get; set; }

        //Max 2 Scoops in SmallSize
        //Max 4 Scoops in LargeSize
        //Each Scoop have flavor
        //If Scoop is Soft-Icecream, then it takes up +2 slots in container.

        public List<string>? Accessory { get; set; }

        //Max 2 Accessories in SmallSize
        //Max 3 Accessories in LargeSize


    }
}
