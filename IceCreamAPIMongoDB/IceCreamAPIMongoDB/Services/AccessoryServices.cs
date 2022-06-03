using Microsoft.Extensions.Options;
using IceCreamAPIMongoDB.Models;
using MongoDB.Driver;

namespace IceCreamAPIMongoDB.Data
{
    public class AccessoryServices
    {
        private readonly IMongoCollection<Accessory> _accessory;

        public AccessoryServices(IOptions<AccessoryDbSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);

            _accessory = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<Accessory>(options.Value.IceCreamCollectionName);

        }

        public async Task<List<Accessory>> GetAsync() =>
            await _accessory.Find(_ => true).ToListAsync();

        public async Task<Accessory> GetAsync(string id) =>
            await _accessory.Find(m => m.Id == id).FirstOrDefaultAsync();


        public async Task CreateAsync(Accessory newAccessory) =>
            await _accessory.InsertOneAsync(newAccessory);

        public async Task UpdateAsync(string id, Accessory updateAccessory) =>
            await _accessory.ReplaceOneAsync(m => m.Id == id, updateAccessory);

        public async Task DeleteAsync(string id) =>
            await _accessory.DeleteOneAsync(m => m.Id == id);


    }
}
