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
    }
}
