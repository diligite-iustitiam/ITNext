using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebProjectOnAzure.Data;
using Shop.Domain;
using WebProjectOnAzure.Services;
using Shop.Application.Interfaces;
using Shop.Application.Products.Queries.GetProductList;

namespace WebProjectOnAzure.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITShopService _shopService;
        private readonly IShopDbContext _shopContext;
       

        public HomeController(ILogger<HomeController> logger, IShopDbContext shopContext)
        {
            _shopContext = shopContext;
            _logger = logger;
            
            
        }


        public async Task<ActionResult<ProductListVm>> Index()
        {
            var query = new GetProductListQuery();

            var vm = await Mediator?.Send(query);

            return View(vm);
        }
        public IActionResult AdminIndex()
        {
            return View();
        }
        public IActionResult Service()
        {

            return View();
        }
        public IActionResult ServiceDetail()
        {
            return View();
        }
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult BlogDetail()
        {
            return View();
        }
        public IActionResult BlogGrid()
        {
            return View();
        }
        public IActionResult ShopDetail()
        {
            return View();
        }
       
        public IActionResult FAQ()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Price()
        {
            return View();
        }
        public IActionResult CheckOut()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Appointment()
        {
            return View();
        }


    }
}