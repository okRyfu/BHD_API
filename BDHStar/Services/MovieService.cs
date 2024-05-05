using Amazon.Runtime.Internal.Auth;
using MongoDB.Driver;
using BDHStar.Models;
using Microsoft.Extensions.Options;

namespace BDHStar.Services
{
    public class MovieService
    {
        private readonly IMongoCollection<Movies> _movieCollection;
        public MovieService(IOptions<BHDDatabaseSettings> setting)
        {
            var mongoClient = new MongoClient(
            setting.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                setting.Value.DatabaseName);

            _movieCollection = mongoDatabase.GetCollection<Movies>(
            setting.Value.MovieCollectionName);
        }

        public async Task<List<Movies>> GetAsync() =>
        await _movieCollection.Find(_ => true).ToListAsync();

        public async Task<Movies?> GetAsync(string ID) =>
            await _movieCollection.Find(x => x.id == ID).FirstOrDefaultAsync();

        public async Task CreateAsync(Movies newMovie) =>
            await _movieCollection.InsertOneAsync(newMovie);

        public async Task UpdateAsync( Movies update)
        {
            var filter = Builders<Movies>.Filter.Eq(x => x.id, update.id);
            var updatedMovie = Builders<Movies>.Update.Set(x => x.title, update.title).Set(x => x.description, update.description)
                                               .Set(x => x.thumbnail, update.thumbnail).Set(x => x.director, update.director)
                                               .Set(x => x.actor,update.actor ).Set(x => x.category, update.category)
                                               .Set(x => x.start_day, update.start_day).Set(x => x.lenght, update.lenght)
                                               .Set(x => x.language, update.language).Set(x => x.trailer, update.trailer);
            await _movieCollection.UpdateOneAsync(filter, updatedMovie);
        }


        public async Task RemoveAsync(string ID) =>
            await _movieCollection.DeleteOneAsync(x => x.id == ID);

    } 
}
