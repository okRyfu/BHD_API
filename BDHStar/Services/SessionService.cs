using BDHStar.Models;
using BHDStar.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace BHDStar.Services
{
    public class SessionService
    {
        private readonly IMongoCollection<Room> _roomCollection;
        private readonly IMongoCollection<Session> _sessionsCollection;
        private readonly IMongoCollection<Movies> _movieColllection;

        public SessionService(IOptions<BHDDatabaseSettings> setting)
        {
            var mongoClient = new MongoClient(setting.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(setting.Value.DatabaseName);

            _sessionsCollection = mongoDatabase.GetCollection<Session>(setting.Value.SessionCollection);

            _roomCollection = mongoDatabase.GetCollection<Room>(setting.Value.RoomCollectionName);
            _movieColllection = mongoDatabase.GetCollection<Movies>(setting.Value.MovieCollectionName);
        }
        public async Task<List<Session>> GetAsync() =>
            await _sessionsCollection.Find(_ => true).ToListAsync();

        public async Task<Session?> GetAsync(string ID) =>
            await _sessionsCollection.Find(x => x.id == ID).FirstOrDefaultAsync();

        public async Task CreateAsync(Session newSession, string idRoom, string idMovie)
        {
            //tìm room để insert vào
            var filterRoom = Builders<Room>.Filter.Eq(x => x.id, idRoom);
            newSession.Room = _roomCollection.Find(filterRoom).Single();
            //tìm movie để insert vào
            var filterMovie = Builders<Movies>.Filter.Eq(x => x.id, idMovie);
            newSession.movie = _movieColllection.Find(filterMovie).Single();
            await _sessionsCollection.InsertOneAsync(newSession);
        }

        public async Task UpdateAsync(Session update)
        {
            var filter = Builders<Session>.Filter.Eq(x => x.id, update.id);

            var updatedMovie = Builders<Session>.Update.Set(x => x.cost, update.cost).Set(x => x.ShowTime, update.ShowTime)
                                   .Set(x => x.movie, update.movie).Set(x => x.Room, update.Room);

            await _sessionsCollection.UpdateOneAsync(filter, updatedMovie);
        }

        public async Task RemoveAsync(string ID) =>
            await _sessionsCollection.DeleteOneAsync(x => x.id == ID);

        public async Task<List<Session>> Paging(int page, int pageSize)
        {
            IMongoQueryable<Session> sessions = _sessionsCollection.AsQueryable().OrderByDescending(x => x.id).Skip((page-1)*pageSize).Take(pageSize);
            return await sessions.ToListAsync();
        }

    }
}
