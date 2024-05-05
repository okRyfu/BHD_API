using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BDHStar.Models
{
    public class Movies
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string thumbnail { get; set; }
        public string director { get; set; }
        public string actor { get; set; }
        public string category { get; set; }
        public DateTime? start_day { get; set; }
        public int lenght { get; set; }
        public string language { get; set; }
        public string trailer { get; set; }

    }
}
