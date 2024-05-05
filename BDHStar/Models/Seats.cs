using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BHDStar.Models
{
    public class Seats
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public int row { get; set; }
        public int column { get; set; }
        public string idRoom { get; set; }
        public bool status { get; set; }
        public string sessionId { get; set; }
    }
}
