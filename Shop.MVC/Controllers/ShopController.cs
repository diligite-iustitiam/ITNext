
using WebProjectOnAzure.Services;
using WebProjectOnAzure.Models;
using Microsoft.AspNetCore.Mvc;


namespace WebProjectOnAzure.Controllers
{

    public class ShopController : Controller
    {
        private readonly ITShopService _shopService;

        public  ShopController(ITShopService shopService) =>
            _shopService = shopService;
        public ActionResult Index()
        {
            List<ITShop> tShops = _shopService.Get().ToList();
            return View(tShops);
        }
        public ActionResult Shop()
        {
            List<ITShop> courses = _shopService.Get().ToList();
            return View(courses);
        }
        public ActionResult ShopDetail(string id)
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
        public ActionResult ShopIndex(int pg = 1)
        {
            List<ITShop> courses = _shopService.Get().ToList();
            const int pageSize = 5;
            if (pg < 1)
                pg = 1;
            int recsCount = courses.Count;
            var pager = new Pager(recsCount, pg, pageSize);
            int recsSkip = (pg - 1) * pageSize;
            var data = courses.Skip(recsSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;
            return View( data);
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
