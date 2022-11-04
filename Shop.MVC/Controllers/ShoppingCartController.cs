using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebProjectOnAzure.Data;
using Shop.Domain;
using WebProjectOnAzure.Helpers;
using WebProjectOnAzure.ViewModels;
using Shop.Application.Interfaces;
using Shop.Application.Products.Queries.GetProductDetails;

namespace WebProjectOnAzure.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShopDbContext _context;
        public ShoppingCartController(IShopDbContext context)
        {
            _context = context;
        }
        // GET: ShoppingCartController
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Product.Price * item.Count);
            ViewBag.total = Math.Round(ViewBag.total, 2);
            return View();
        }
        private int isExist(int id)
        {
            List<Cart> cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ProductID.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
        public IActionResult Buy(int id)
        {
         

            if (SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart") == null)
            {
                List<Cart> cart = new List<Cart>();
                cart.Add(new Cart { Product = _context.Products.Find(id), Count = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Cart> cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Count++;
                }
                else
                {
                    cart.Add(new Cart { Product = _context.Products.Find(id), Count = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            List<Cart> cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");

        }
    }
}
