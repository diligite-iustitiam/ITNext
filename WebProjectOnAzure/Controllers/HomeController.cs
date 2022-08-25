using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

using WebProjectOnAzure.Models;
using WebProjectOnAzure.Services;

namespace WebProjectOnAzure.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITShopService _shopService;
       

        public HomeController(ILogger<HomeController> logger, ITShopService shopService)
        {
            _logger = logger;
            _shopService = shopService;
            
        }


        public IActionResult Index()
        {

            List<ITShop> tShops = _shopService.Get().ToList();
            return View(tShops);
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



    }
}