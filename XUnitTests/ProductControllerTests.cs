//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Moq;
//using WebProjectOnAzure.Controllers;
//using WebProjectOnAzure.Data;
//using WebProjectOnAzure.Interface;
//using Shop.Domain

//namespace XUnitTests
//{
//    public class ProductControllerTests
//    {
//        private Mock<IProductRepository>? _productRepo;
//        private Mock<ICategoryRepository>? _categoryRepo;
//        private ProductController? productController;
//        public ProductControllerTests()
//        {
//            _productRepo = new Mock<IProductRepository>();
//            _categoryRepo = new Mock<ICategoryRepository>();
//            _productRepo.Setup(x => x.GetProductsWithCategory()).Returns(GetTestProducts());
//            _categoryRepo.Setup(x => x.GetCategories()).Returns(GetTestCategories());
//            productController = new ProductController(_productRepo.Object,_categoryRepo.Object);
            
//        }
//        [Fact]
//        public async Task TestIndex()
//        {
//            var result = productController.Index();
//            var viewResult = Assert.IsType<ViewResult>(await result);
//            var model = Assert.IsAssignableFrom<IEnumerable<Product>>(
//        viewResult.ViewData.Model);
//            Assert.Equal(2, model.Count());
            
//        }
//        private List<Category> GetTestCategories()
//        {
//            var categories = new List<Category>();
//            categories.Add(new Category()
//            {
//                CategoryID = 45,
//                CategoryName ="aoba",
//                CategoryPhoto = "gfd",
//                Description="dsfs"
               
//            });
//            return categories;
//        }
//        private async Task<List<Product>> GetTestProducts()
//        {
//            var products = new List<Product>();
//            products.Add(new Product()
//            {
//                ProductID = 56,
//                ProductBrand = "A",
//                ProductModel = "B",
//                Price = 12312,
//                ProductDescription = "s",
//                ProductImage = "34",
//                CategoryID = 3
//            });
//            products.Add(new Product()
//            {
//                ProductID = 78,
//                ProductBrand = "Aaasdsdsas",
//                ProductModel = "Bsaasdasdas",
//                Price = 123121,
//                ProductDescription = "saw",
//                ProductImage = "34as",
//                CategoryID = 3
//            });
//            return  products;
//        }
//    }
//}
