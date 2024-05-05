using BDHStar.Models;
using BHDStar.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BHDStar.Services
{
    public class MovieTheatreService
    {
        private readonly IMongoCollection<MovieTheatres> _theatreCollection;
        public MovieTheatreService(IOptions<BHDDatabaseSettings> setting)
        {
            var mongoClient = new MongoClient(
            setting.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                setting.Value.DatabaseName);

            _theatreCollection = mongoDatabase.GetCollection<MovieTheatres>(
            setting.Value.MovieTheatreCollectionName);
        }

        public async Task<List<MovieTheatres>> GetAsync() =>
        await _theatreCollection.Find(_ => true).ToListAsync();

        public async Task<MovieTheatres?> GetAsync(string ID) =>
            await _theatreCollection.Find(x => x.id == ID).FirstOrDefaultAsync();

        public async Task CreateAsync(MovieTheatres newTheatre) =>
            await _theatreCollection.InsertOneAsync(newTheatre);

        public async Task UpdateAsync(MovieTheatres update)
        {
            var filter = Builders<MovieTheatres>.Filter.Eq(x => x.id, update.id);
            var updated = Builders<MovieTheatres>.Update.Set(x => x.title, update.title).Set(x => x.locate, update.locate)
                                               .Set(x => x.email, update.email).Set(x => x.roomCount, update.roomCount);
            await _theatreCollection.UpdateOneAsync(filter, updated);
        }


        public async Task RemoveAsync(string ID) =>
            await _theatreCollection.DeleteOneAsync(x => x.id == ID);
    }
}
