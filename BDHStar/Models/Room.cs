using BHDStar.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BHDStar.Models
{
    public class Room
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string name { get; set; }
        public MovieTheatres MovieTheatres { get; set; }
    }
}
