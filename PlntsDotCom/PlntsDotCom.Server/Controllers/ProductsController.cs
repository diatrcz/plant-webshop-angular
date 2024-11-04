using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlntsDotCom.Server.Data;
using PlntsDotCom.Server.Models;
using PlntsDotCom.Server.Search;
using System.Net;

namespace PlntsDotCom.Server.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductsController(ApplicationDbContext context) => _context = context;

        [HttpGet(Name = "GetProducts")]
        public List<Product> Get()
        {
            return _context.Products.ToList();
        }

        [HttpGet("details/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public ActionResult<Product> GetProduct(int id) {

            var a = _context.Products.SingleOrDefault(m => m.Id == id);
            if (a is null)
            {
                return NotFound();
            }

            return a;
        }

        [HttpGet("shop/{categoryName}")]
        public List<Product> GetProductsByCategory(string categoryName, [FromQuery] SearchModel searchModel)
        {
            int parentCategoryId = _context.Categories
                                    .Where(c => c.Name == categoryName)
                                    .Select(c => c.Id)
                                    .SingleOrDefault();

            var products = _context.Products
                                    .Where(p => p.CategoryId == parentCategoryId || p.Category.ParentCategoryId == parentCategoryId)
                                    .Where(searchModel.PriceMin is not null, p => p.Price >= searchModel.PriceMin)
                                    .Where(searchModel.PriceMax is not null, p => p.Price <= searchModel.PriceMax)
                                    .ToList();

            return products;

        }

        [HttpGet("search/{searchQuery}")]
        public List<Product> SearchProducts(string searchQuery)
        {
            var queryTerms = searchQuery.Split(' ');

                var results = _context.Products.Where(
                    p => queryTerms.Any(term =>
                    (p.Name + p.Category.Name + p.Category.ParentCategory.Name).Contains(term)))
                    .ToList();

            return results;
        }


        [HttpPost("edit")]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var existingProduct = await _context.Products.FindAsync(product.Id);
                if (existingProduct == null)
                {
                    return NotFound();
                }

                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Stock = product.Stock;
                existingProduct.Description = product.Description;
                existingProduct.ImageUrl = product.ImageUrl;

                await _context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest(ModelState); 
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("add")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _context.Categories.FindAsync(product.CategoryId);
            if (category == null)
            {
                return BadRequest("Invalid Category ID.");
            }

            var newProduct = new Product
            {
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                CategoryId = product.CategoryId 
            };

            try
            {
                await _context.Products.AddAsync(newProduct);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetProduct), new { id = newProduct.Id }, newProduct);
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode(500, new { message = "Database error occurred.", details = dbEx.InnerException?.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }

    }
}
