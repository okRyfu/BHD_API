using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using BDHStar.Models;

namespace BHDStar.Models
{
    public class Session
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public Room Room { get; set; }
        public Movies movie { get; set; }
        public DateTime ShowTime { get; set; }
        public int cost { get; set; }
    }
}