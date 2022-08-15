using WebApiOnAzure.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace WebApiOnAzure.Services
{
    public class ITShopService
    {
        private readonly IMongoCollection<ITShop> _shopCollection;

        public ITShopService(
            IOptions<ITShopDatabaseSettings> bookStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                bookStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                bookStoreDatabaseSettings.Value.DatabaseName);

            _shopCollection = mongoDatabase.GetCollection<ITShop>(
                bookStoreDatabaseSettings.Value.ShopsCollectionName);
        }

        public async Task<List<ITShop>> GetAsync() =>
            await _shopCollection.Find(_ => true).ToListAsync();

        public async Task<ITShop?> GetAsync(string id) =>
            await _shopCollection.Find(x => x.ITProductID == id).FirstOrDefaultAsync();

        public async Task CreateAsync(ITShop newBook) =>
            await _shopCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, ITShop updatedBook) =>
            await _shopCollection.ReplaceOneAsync(x => x.ITProductID == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _shopCollection.DeleteOneAsync(x => x.ITProductID == id);
    }
}
