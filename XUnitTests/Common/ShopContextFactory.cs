using Xunit;
using Shop.Domain;
using Shop.Persistence;
using Microsoft.EntityFrameworkCore;

namespace XUnitTests.Common
{
    public class ShopContextFactory
    {       

        public static int ProductIdForDelete = 33;
        public static int ProductIdForUpdate = 34;

        public static ShopContext Create()
        {
            var options = new DbContextOptionsBuilder<ShopContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ShopContext(options);
            context.Database.EnsureCreated();
            context.Products.AddRange(
                new Product
                {
                    ProductID = 33,
                    ProductBrand = "Moto",
                    ProductModel = "Boto",
                    ProductDescription = "1st Test",
                    Price = 1,
                    CategoryID = 1,
                    ProductImage = "Nice to have"
                },
                new Product
                {
                    ProductID = 34,
                    ProductBrand = "Asus",
                    ProductModel = "Big",
                    ProductDescription = "2st Test",
                    Price = 2,
                    CategoryID = 2,
                    ProductImage = "Nice to have"
                },
                new Product
                {
                    ProductID = 35,
                    ProductBrand = "MSI",
                    ProductModel = "small",
                    ProductDescription = "3st Test",
                    Price = 3,
                    CategoryID = 3,
                    ProductImage = "Nice to have"
                },
                new Product
                {
                    ProductID = 36,
                    ProductBrand = "Nvidia",
                    ProductModel = "Cool",
                    ProductDescription = "5st Test",
                    Price = 4,
                    CategoryID = 4,
                    ProductImage = "Nice to have"
                }
            );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(ShopContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
