
using Shop.Domain
using WebProjectOnAzure.Controllers;
using NUnit.Framework;
using WebProjectOnAzure.Data;

namespace NUnitTests
{
    [TestFixture]
    public class ProductControllerTest
    {
        private ProductController? _controller;
        private ShopContext? _shopContext;
        [SetUp]
        public void SetupTest()
        {
            _shopContext = new ShopContext();
            _controller = new ProductController(_shopContext);
        }

        [Test]
        public void Test_ProductDetail_ShouldReturnProduct()
        {
            var shop = _controller.ProductDetail(1);
            Assert.IsNotNull(shop);
        }
    }
}