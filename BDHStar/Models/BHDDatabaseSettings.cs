namespace BDHStar.Models
{
    public class BHDDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;
        public string MovieCollectionName { get; set; } = null!;
        public string MovieTheatreCollectionName { get; set; } = null!;
        public string RoomCollectionName { get; set; } = null!;
        public string SessionCollection { get; set; } = null!;
    }
}
