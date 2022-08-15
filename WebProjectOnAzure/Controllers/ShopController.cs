using Microsoft.AspNetCore.Http;
using WebProjectOnAzure.Services;
using WebProjectOnAzure.Models;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebProjectOnAzure.Controllers
{

    public class ShopController : Controller
    {
        private readonly ITShopService _shopService;

        public ShopController(ITShopService shopService) =>
            _shopService = shopService;
        public ActionResult ShopIndex()
        {
            return View(_shopService.Get());
        }

        // GET: Cars/Details/5
        public IActionResult ProductDetails(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shop = _shopService.Get(id);
            if (shop == null)
            {
                return NotFound();
            }
            return View(shop);
        }

        // GET: Cars/Create
        public IActionResult ProductCreate()
        {
            return View();
        }

        // POST: Cars/Create/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProductCreate(ITShop shop)
        {
            if (ModelState.IsValid)
            {
                _shopService.Create(shop);
                return RedirectToAction(nameof(ShopIndex));
            }
            return View(shop);
        }

        // GET: Cars/Edit/5
        public IActionResult ProductEdit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shop = _shopService.Get(id);
            if (shop == null)
            {
                return NotFound();
            }
            return View(shop);
        }

        // POST: Cars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProductEdit(string id, ITShop shop)
        {
            if (id != shop.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _shopService.Update(id, shop);
                return RedirectToAction(nameof(ShopIndex));
            }
            else
            {
                return View(shop);
            }
        }

        // GET: Cars/Delete/5

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shop = _shopService.Get(id);
            if (shop == null)
            {
                return NotFound();
            }
            return View(shop);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                var car = _shopService.Get(id);

                if (car == null)
                {
                    return NotFound();
                }

                _shopService.Remove(car.Id);

                return RedirectToAction(nameof(ShopIndex));
            }
            catch
            {
                return View();
            }
        }
    }
}
