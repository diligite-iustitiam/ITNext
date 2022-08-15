using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiOnAzure.Models;
using WebApiOnAzure.Services;

namespace WebApiOnAzure.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShopController : Controller
    {
        private readonly ITShopService _booksService;

        public ShopController(ITShopService booksService) =>
            _booksService = booksService;

        [HttpGet]
        public async Task<List<ITShop>> Get() =>
            await _booksService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<ITShop>> Get(string id)
        {
            var book = await _booksService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ITShop newBook)
        {
            await _booksService.CreateAsync(newBook);

            return CreatedAtAction(nameof(Get), new { id = newBook.ITProductID }, newBook);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, ITShop updatedBook)
        {
            var book = await _booksService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            updatedBook.ITProductID = book.ITProductID;

            await _booksService.UpdateAsync(id, updatedBook);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _booksService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            await _booksService.RemoveAsync(id);

            return NoContent();
        }
    }
}
