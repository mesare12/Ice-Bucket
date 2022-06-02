using Microsoft.Extensions.Options;
using IceCreamAPIMongoDB.Models;
using MongoDB.Driver;

namespace IceCreamAPIMongoDB.Data
{
    public class VendorServices
    {
        private readonly IMongoCollection<Vendor> _vendor;

        public VendorServices(IOptions<IceCreamDatabaseSettings > options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);

            _vendor = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<Vendor>(options.Value.IceCreamCollectionName);

        }

        public async Task<List<Vendor>> GetAsync() =>
            await _vendor.Find(_ => true).ToListAsync();

        public async Task<Vendor> GetAsync(string id) =>
            await _vendor.Find(m => m.Id == id).FirstOrDefaultAsync();
     

        public async Task CreateAsync(Vendor newVendor) =>
            await _vendor.InsertOneAsync(newVendor);

        public async Task UpdateAsync(string id, Vendor updateVendor) =>
            await _vendor.ReplaceOneAsync(m => m.Id == id, updateVendor);

        public async Task DeleteAsync(string id) =>
            await _vendor.DeleteOneAsync(m =>m.Id == id);


    }
}
