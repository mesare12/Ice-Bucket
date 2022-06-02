using Microsoft.Extensions.Options;
using IceCreamAPIMongoDB.Models;
using MongoDB.Driver;

namespace IceCreamAPIMongoDB.Data
{
    public class VendorServices
    {
        private readonly IMongoCollection<Vendor> _icecream;

        public VendorServices(IOptions<IceCreamDatabaseSettings > options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);

            _icecream = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<Vendor>(options.Value.IceCreamCollectionName);

        }

        public async Task<List<Vendor>> GetAsync() =>
            await _icecream.Find(_ => true).ToListAsync();

        public async Task<Vendor> GetAsync(string id) =>
            await _icecream.Find(m => m.Id == id).FirstOrDefaultAsync();
     

        public async Task CreateAsync(Vendor newIceCream) =>
            await _icecream.InsertOneAsync(newIceCream);

        public async Task UpdateAsync(string id, Vendor updateIceCream) =>
            await _icecream.ReplaceOneAsync(m => m.Id == id, updateIceCream);

        public async Task DeleteAsync(string id) =>
            await _icecream.DeleteOneAsync(m =>m.Id == id);


    }
}
