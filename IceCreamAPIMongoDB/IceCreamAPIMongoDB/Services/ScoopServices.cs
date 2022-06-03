using Microsoft.Extensions.Options;
using IceCreamAPIMongoDB.Models;
using MongoDB.Driver;

namespace IceCreamAPIMongoDB.Data
{
    public class ScoopServices
    {
        private readonly IMongoCollection<ScoopItem> _scoop;

        public ScoopServices(IOptions<ScoopDbSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);

            _scoop = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<ScoopItem>(options.Value.IceCreamCollectionName);
        }

        public async Task<List<ScoopItem>> GetAsync() =>
            await _scoop.Find(_ => true).ToListAsync();

        public async Task<ScoopItem> GetAsync(string id) =>
            await _scoop.Find(m => m.Id == id).FirstOrDefaultAsync();


        public async Task CreateAsync(ScoopItem newScoop) =>
            await _scoop.InsertOneAsync(newScoop);

        public async Task UpdateAsync(string id, ScoopItem updateScoop) =>
            await _scoop.ReplaceOneAsync(m => m.Id == id, updateScoop);

        public async Task DeleteAsync(string id) =>
            await _scoop.DeleteOneAsync(m => m.Id == id);


    }
}
