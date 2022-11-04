using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;
using Shop.Domain;
using Shop.MVC.Interfaces;
namespace Shop.MVC.Services
{
    public class ProductService : IProductService
    {
        private readonly IShopDbContext? _context;
        public ProductService(IShopDbContext context) {
        _context = context;
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
                switch (sortBy.Value)
                {

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
        public async Task<int> SearchProductsCount(string searchTerm, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy, List<int>? pictureIDs)
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
