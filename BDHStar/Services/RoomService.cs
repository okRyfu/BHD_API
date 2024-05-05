using BDHStar.Models;
using BHDStar.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BHDStar.Services
{
    public class RoomService
    {
        private readonly IMongoCollection<Room> _roomCollection;
        private readonly IMongoCollection<MovieTheatres> _theatreCollection;
        public RoomService(IOptions<BHDDatabaseSettings> setting)
        {
            var mongoClient = new MongoClient(setting.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(setting.Value.DatabaseName);
            _roomCollection = mongoDatabase.GetCollection<Room>(setting.Value.RoomCollectionName);
            _theatreCollection = mongoDatabase.GetCollection<MovieTheatres>(setting.Value.MovieTheatreCollectionName);
        }
        public async Task<List<Room>> GetAsync()=>
            await _roomCollection.Find(_ => true).ToListAsync();
        public async Task<Room?> GetAsync(string ID) =>
            await _roomCollection.Find(x => x.id == ID).FirstOrDefaultAsync();

        public async Task CreateAsync(Room newRoom,string idTheatre)
        {
            var filter = Builders<MovieTheatres>.Filter.Eq(x => x.id, idTheatre);
            newRoom.MovieTheatres= _theatreCollection.Find(filter).Single();
            await _roomCollection.InsertOneAsync(newRoom);
        }

        public async Task UpdateAsync(Room update)
        {
            var filter =  Builders<Room>.Filter.Eq(x=>x.id,update.id);
            var updatedRoom = Builders<Room>.Update.Set(x=>x.name,update.name).Set(x=>x.MovieTheatres,update.MovieTheatres);
            await _roomCollection.UpdateOneAsync(filter,updatedRoom);
        }

        public async Task RemoveAsync(string ID) =>
            await _roomCollection.DeleteOneAsync(x => x.id==ID);
    }
}
