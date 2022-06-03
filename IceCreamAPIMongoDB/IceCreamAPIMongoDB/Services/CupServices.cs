using Microsoft.Extensions.Options;
using IceCreamAPIMongoDB.Models;
using MongoDB.Driver;

namespace IceCreamAPIMongoDB.Data
{
    public class CupServices
    {
        private readonly IMongoCollection<Cup> _cup;

        public CupServices(IOptions<CupDbSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);

            _cup = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<Cup>(options.Value.IceCreamCollectionName);

        }

        public async Task<List<Cup>> GetAsync() =>
            await _cup.Find(_ => true).ToListAsync();

        public async Task<Cup> GetAsync(string id) =>
            await _cup.Find(m => m.Id == id).FirstOrDefaultAsync();


        public async Task CreateAsync(Cup newCup) =>
            await _cup.InsertOneAsync(newCup);
        
        public async Task UpdateAsync(string id, Cup upupdateCup) =>
            await _cup.ReplaceOneAsync(m => m.Id == id, upupdateCup);

        public async Task DeleteAsync(string id) =>
            await _cup.DeleteOneAsync(m => m.Id == id);


    }
}
