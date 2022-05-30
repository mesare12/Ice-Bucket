using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace IceCreamAPIMongoDB.Data
{
    public class IceCreamServices
    {
        private readonly IMongoCollection<IceCream> _icecream;

        public IceCreamServices(IOptions<IceCreamDatabaseSettings > options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);

            _icecream = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<IceCream>(options.Value.IceCreamCollectionName);


        }

        public async Task<List<IceCream>> GetAsync() =>
            await _icecream.Find(_ => true).ToListAsync();

        public async Task<IceCream> GetAsync(string id) =>
            await _icecream.Find(m => m.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(IceCream newIceCream) =>
            await _icecream.InsertOneAsync(newIceCream);

        public async Task UpdateAsync(string id, IceCream updateIceCream) =>
            await _icecream.ReplaceOneAsync(m => m.Id == id, updateIceCream);

        public async Task DeleteAsync(string id) =>
            await _icecream.DeleteOneAsync(m =>m.Id == id);


    }
}
