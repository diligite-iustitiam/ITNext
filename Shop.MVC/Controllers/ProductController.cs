
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Shop.Application.Interfaces;
using Shop.Application.Products.Commands.DeleteProduct;
using Shop.Application.Products.Commands.UpdateProduct;
using Shop.Application.Products.CreateProduct;
using Shop.Application.Products.Queries.GetProductDetails;
using Shop.Application.Products.Queries.GetProductList;
using WebProjectOnAzure.Models;
using static WebProjectOnAzure.ViewModels.ShopViewModels;
using Shop.MVC.Interfaces;

namespace Shop.MVC.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IShopDbContext _context;
        private readonly IProductService _service;

        public ProductController(IShopDbContext context, IMapper mapper, IProductService service)
        {
            _context = context;
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ProductListVm>> Index()
        {
            var query = new GetProductListQuery();
            var vm = await Mediator.Send(query);
            return View(vm);
        }

        [Authorize]
        public async Task<ActionResult<ProductDetailsVm>> Details(int productID)
        {
            var query = new GetProductDetailsQuery
            {
                ProductID = productID
            };
            var vm = await Mediator.Send(query);
            return View(vm);
        }

        [Authorize]
        public IActionResult Create(CreateDTOProduct createproduct)
        {
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", createproduct.CategoryID);
            return View(createproduct);
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id,[FromForm] CreateDTOProduct createproduct)
        {
            var command = _mapper.Map<CreateProductCommand>(createproduct);          
            var product = await Mediator.Send(command);
            return View(product);
        }
        
        public async Task<ActionResult<ProductDetailsVm>> ProductDetail(int productID)
        {
            ViewBag.products = await _context.Products.ToListAsync();
            var query = new GetProductDetailsQuery
            {
                ProductID = productID
            };
            var vm = await Mediator.Send(query);
            return View(vm);
        }
        [Authorize]
        public IActionResult Edit(int id,UpdateDTOProduct updateProductDto)
        {
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", updateProductDto.CategoryID);
            var command = _mapper.Map<UpdateProductCommand>(updateProductDto);
            return View(updateProductDto);
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(UpdateDTOProduct updateProductDto)
        {
            var command = _mapper.Map<UpdateProductCommand>(updateProductDto);
            await Mediator.Send(command);
            return View(updateProductDto);
        }
        [Authorize]
        public async Task<ActionResult<ProductDetailsVm>> Delete(int productID)
        {
            var query = new GetProductDetailsQuery
            {
                ProductID = productID
            };
            var vm = await Mediator.Send(query);
            return View(vm);
        }

        public async Task<IActionResult> DeleteConfirmed(int productID)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'ShopContext.Products'  is null.");
            }
            var command = new DeleteProductCommand
            {
                ProductID = productID
            };
            await Mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ProductShop(string searchTerm, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy, int? pageNo, int? shopstyle, string ItemIds)
        {
            int pageSize = 8;
            List<int> pictureIDs = !string.IsNullOrEmpty(ItemIds) ? ItemIds.Split(',').Select(x => int.Parse(x)).ToList() : new List<int>();
            int totalCount = await _service.SearchProductsCount(searchTerm, minimumPrice, maximumPrice, categoryID, sortBy, pictureIDs);
            pageNo = pageNo.HasValue ? shopstyle.Value > 0 ? pageNo.Value : 1 : 1;

            var model = new ShopModel 
            {
                SearchTerm = searchTerm,
                CategoryID = categoryID,
                Categories = await _context.Categories.ToListAsync(),
                ShopStyle = shopstyle.HasValue ? shopstyle.Value > 0 ? shopstyle.Value : 1 : 1,
                MaximumPrice = maximumPrice.HasValue ? maximumPrice.Value > 0 ? maximumPrice.Value : ((int)_context.Products.Max(x => x.Price)) : ((int)_context.Products.Max(x => x.Price)),
                MinPrice = minimumPrice.HasValue ? minimumPrice.Value > 0 ? minimumPrice.Value : 0 : 0,
                InitialMaximumPrice = (int)_context.Products.Max(x => x.Price),
                CategoryCheckIds = pictureIDs,
                SortBy = sortBy,
                Products = await _service.SearchProducts(searchTerm, minimumPrice, maximumPrice, categoryID, sortBy, pageNo.Value, pageSize, pictureIDs),
                Pager = new Pager(totalCount, pageNo, pageSize)
            };
                     
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> FilterForProduct(string searchTerm, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy, int? pageNo, int? shopstyle, string ItemIds)
        {
            int pageSize = 8;
            List<int> pictureIDs = !string.IsNullOrEmpty(ItemIds) ? ItemIds.Split(',').Select(x => int.Parse(x)).ToList() : new List<int>();
            int totalCount = await _service.SearchProductsCount(searchTerm, minimumPrice, maximumPrice, categoryID, sortBy, pictureIDs);
            pageNo = pageNo.HasValue ? shopstyle.Value > 0 ? pageNo.Value : 1 : 1;
            var model = new FilterViewModel
            {
                SearchTerm = searchTerm,
                CategoryID = categoryID,
                Categories = await _context.Categories.ToListAsync(),
                ShopStyle = shopstyle.HasValue ? shopstyle.Value > 0 ? shopstyle.Value : 1 : 1,
                MaximumPrice = maximumPrice.HasValue ? maximumPrice.Value > 0 ? maximumPrice.Value : ((int)_context.Products.Max(x => x.Price)) : ((int)_context.Products.Max(x => x.Price)),
                MinPrice = minimumPrice.HasValue ? minimumPrice.Value > 0 ? minimumPrice.Value : 0 : 0,
                InitialMaximumPrice = (int)_context.Products.Max(x => x.Price),
                CategoryCheckIds = pictureIDs,
                SortBy = sortBy,
                Products = await _service.SearchProducts(searchTerm, minimumPrice, maximumPrice, categoryID, sortBy, pageNo.Value, pageSize, pictureIDs),
                Pager = new Pager(totalCount, pageNo, pageSize)
            };
          
            return PartialView(model);

        }


        private bool ProductExists(int id)
        {
          return (_context.Products?.Any(e => e.ProductID == id)).GetValueOrDefault();
        }  
        
        public IActionResult Error()
        {
            return View();
        }
    }
}
