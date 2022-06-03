using Microsoft.Extensions.Options;
using IceCreamAPIMongoDB.Models;
using MongoDB.Driver;

namespace IceCreamAPIMongoDB.Data
{
    public class OrderServices
    {
        private readonly IMongoCollection<Order> _order;

        public OrderServices(IOptions<OrderDbSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);

            _order = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<Order>(options.Value.IceCreamCollectionName);

        }

        public async Task<List<Order>> GetAsync() =>
            await _order.Find(_ => true).ToListAsync();

        public async Task<Order> GetAsync(string id) =>
            await _order.Find(m => m.Id == id).FirstOrDefaultAsync();


        public async Task CreateAsync(Order newOrder) =>
            await _order.InsertOneAsync(newOrder);

        public async Task UpdateAsync(string id, Order updateOrder) =>
            await _order.ReplaceOneAsync(m => m.Id == id, updateOrder);

        public async Task DeleteAsync(string id) =>
            await _order.DeleteOneAsync(m => m.Id == id);


    }
}
