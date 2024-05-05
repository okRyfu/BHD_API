using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace BHDStar.Models
{


    public class MovieTheatres
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string title { get; set; }
        public string locate { get; set; }
        public string email { get; set; }
        public int roomCount { get; set; }


    }
}
