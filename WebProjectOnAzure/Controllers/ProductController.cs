using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProjectOnAzure.Data;
using WebProjectOnAzure.Models;
using WebProjectOnAzure.ViewModels;
using static WebProjectOnAzure.ViewModels.ShopViewModels;

namespace WebProjectOnAzure.Controllers
{
    public class ProductController : Controller
    {
        private readonly ShopContext _context;
        
        public ProductController(ShopContext context)
        {
            _context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            var shopContext = _context.Products.Include(p => p.Category);
            return View(await shopContext.ToListAsync());
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID");
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
  
        public async Task<IActionResult> ProductShop(string searchTerm, int? minimumPrice, int? maximumPrice,int? categoryID, int? sortBy, int? pageNo, int? shopstyle, string ItemIds)
        {
            int pageSize = 8;
           
            List<int> pictureIDs = !string.IsNullOrEmpty(ItemIds) ? ItemIds.Split(',').Select(x => int.Parse(x)).ToList() : new List<int>();

            ShopModel model = new();
            model.SearchTerm = searchTerm;
            model.CategoryID = categoryID;
            model.SortBy = sortBy;
            pageNo = pageNo.HasValue ? shopstyle.Value > 0 ? pageNo.Value : 1 : 1;
            model.Categories = await _context.Categories.ToListAsync();
            model.ShopStyle = shopstyle.HasValue ? shopstyle.Value > 0 ? shopstyle.Value : 1 : 1;
            model.MaximumPrice = maximumPrice.HasValue ? maximumPrice.Value > 0 ? maximumPrice.Value : ((int)_context.Products.Max(x => x.Price)) : ((int)_context.Products.Max(x => x.Price));
            model.MinPrice = minimumPrice.HasValue ? minimumPrice.Value > 0 ? minimumPrice.Value : 0 : 0;
            model.InitialMaximumPrice = (int)_context.Products.Max(x => x.Price);
            model.CategoryCheckIds = pictureIDs;
            int totalCount = await SearchProductsCount(searchTerm, minimumPrice, maximumPrice, categoryID, sortBy, pictureIDs);
            model.Products = await SearchProducts(searchTerm, minimumPrice, maximumPrice, categoryID, sortBy, pageNo.Value, pageSize, pictureIDs);
            model.Pager = new Pager(totalCount, pageNo, pageSize);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> FilterForProduct(string searchTerm, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy, int? pageNo, int? shopstyle, string ItemIds)
        {
            int pageSize = 8;
            List<int> pictureIDs = !string.IsNullOrEmpty(ItemIds) ? ItemIds.Split(',').Select(x => int.Parse(x)).ToList() : new List<int>();          
            FilterViewModel model = new();
            model.SearchTerm = searchTerm;
            model.CategoryID = categoryID;
            model.SortBy = sortBy;
            model.ShopStyle = shopstyle.HasValue ? shopstyle.Value > 0 ? shopstyle.Value : 1 : 1;
            pageNo = pageNo.HasValue ? shopstyle.Value > 0 ? pageNo.Value : 1 : 1;
            model.InitialMaximumPrice = (int)_context.Products.Max(x => x.Price);
            model.Categories = await _context.Categories.ToListAsync();
            model.MaximumPrice = maximumPrice.HasValue ? maximumPrice.Value > 0 ? maximumPrice.Value : ((int)_context.Products.Max(x => x.Price)) : ((int)_context.Products.Max(x => x.Price));
            model.MinPrice = minimumPrice.HasValue ? minimumPrice.Value > 0 ? minimumPrice.Value : 0 : 0;
            
            
            model.CategoryCheckIds = pictureIDs;
            int totalCount = await SearchProductsCount(searchTerm, minimumPrice, maximumPrice, categoryID, sortBy, pictureIDs);
            model.Products = await SearchProducts(searchTerm, minimumPrice, maximumPrice, categoryID, sortBy, pageNo.Value, pageSize, pictureIDs);
            model.Pager = new Pager(totalCount, pageNo, pageSize);
            return PartialView(model);

        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryID,ProductBrand,ProductModel,ProductDescription,Price,ProductImage")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", product.CategoryID);
            return View(product);
        }


        public async Task<IActionResult> ProductDetail(int? id)
        {
            var products = _context.Products.ToList();
            ViewBag.products = products;
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", product.CategoryID);
            return View(product);
        }
        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", product.CategoryID);
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryID,ProductBrand,ProductModel,ProductDescription,Price,ProductImage")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", product.CategoryID);
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'ShopContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.Products?.Any(e => e.ProductID == id)).GetValueOrDefault();
        }
        public enum SortByEnums
        {
            Default = 1,
            Popularity = 2,
            PriceLowToHigh = 3,
            PriceHighToLow = 4
        }
        public async Task<List<Product>> SearchProducts(string searchTerm, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy, int? pageNo, int pageSize, List<int> pictureIDs)
        {
            var products = await _context.Products.ToListAsync();
            

            if (categoryID.HasValue)
            {
                products = products.Where(x => x.CategoryID == categoryID.Value).ToList();
            }
            if (pictureIDs.Any())
            {
                products = products.Where(x => pictureIDs.Contains(x.CategoryID)).ToList();
            }
            
            if (!string.IsNullOrEmpty(searchTerm))
            {
                products = products.Where(x => x.ProductBrand.ToLower().Contains(searchTerm.ToLower())).ToList();
            }
            if (minimumPrice.HasValue)
            {
                products = products.Where(x => x.Price >= minimumPrice.Value).ToList();
            }
            if (maximumPrice.HasValue)
            {
                products = products.Where(x => x.Price <= maximumPrice.Value).ToList();
            }
            if (sortBy.HasValue)
            {
                switch (sortBy.Value) {

                    case 2:
                        products = products.OrderByDescending(x => x.CategoryID).ToList();
                        break;
                    case 3:
                        products = products.OrderBy(x => x.Price).ToList();
                        break;
                    case 4:
                        products = products.OrderByDescending(x => x.Price).ToList();
                        break;
                    default:
                        products = products.OrderByDescending(x => x.Price).ToList();
                        break;

                }


            }
            return products.Skip((int)((pageNo - 1) * pageSize)).Take(pageSize).ToList();
        }
        public async Task<int> SearchProductsCount(string searchTerm,int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy, List<int>? pictureIDs)
        {
            var products = await _context.Products.ToListAsync();
            if (categoryID.HasValue)
            {
                products = products.Where(x => x.CategoryID == categoryID.Value).ToList();
            }
            if (pictureIDs.Any())
            {
                products = products.Where(x => pictureIDs.Contains(x.CategoryID)).ToList();
            }
            
            if (!string.IsNullOrEmpty(searchTerm))
            {
                products = products.Where(x => x.ProductBrand.ToLower().Contains(searchTerm.ToLower())).ToList();
            }
            if (minimumPrice.HasValue)
            {
                products = products.Where(x => x.Price >= minimumPrice.Value).ToList();
            }
            if (maximumPrice.HasValue)
            {
                products = products.Where(x => x.Price <= maximumPrice.Value).ToList();
            }
            if (sortBy.HasValue)
            {
                switch (sortBy.Value)
                {
                    case 2:
                        products = products.OrderByDescending(x => x.CategoryID).ToList();
                        break;
                    case 3:
                        products = products.OrderBy(x => x.Price).ToList();
                        break;
                    default:
                        products = products.OrderByDescending(x => x.Price).ToList();
                        break;
                }

            }
            return products.Count();
        }
    }
}
