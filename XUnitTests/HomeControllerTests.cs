
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Logging.Abstractions;
//using WebProjectOnAzure.Controllers;
//using WebProjectOnAzure.Data;

//namespace XUnitTests.HomeControllerTests
//{
//    public class HomeControllerTests
//    {
//        [Fact]
//        public void TestIndex()
//        {
//            // var homeController = new HomeController(new NullLogger<HomeController>(),new ShopContext());
//            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
//            var logger = loggerFactory.CreateLogger<HomeController>();
//            var homeController = new HomeController(logger, new ShopContext());
//            var result = homeController.Index();
//            var viewResult = Assert.IsType<ViewResult>(result);
//        }
//    }
//}
