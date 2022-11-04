using WebProjectOnAzure.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace WebProjectOnAzure.Services
{
    public class ITShopService
    {
        private readonly IMongoCollection<ITShop> shops;

        public ITShopService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("ITShopDatabase"));
            IMongoDatabase database = client.GetDatabase("ShopDB");
            shops = database.GetCollection<ITShop>("ITShop");
        }

        public List<ITShop> Get()
        {
            return shops.Find(shop => true).ToList();
        }

        public ITShop Get(string id)
        {
            return shops.Find(shop => shop.Id == id).FirstOrDefault();
        }

        public ITShop Create(ITShop shop)
        {
            shops.InsertOne(shop);
            return shop;
        }

        public void Update(string id, ITShop carIn)
        {
            shops.ReplaceOne(shop => shop.Id == id, carIn);
        }

        public void Remove(ITShop carIn)
        {
            shops.DeleteOne(shop => shop.Id == carIn.Id);
        }

        public void Remove(string id)
        {
            shops.DeleteOne(shop => shop.Id == id);
        }
    }
}
