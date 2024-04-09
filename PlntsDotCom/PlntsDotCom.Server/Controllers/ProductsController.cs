using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlntsDotCom.Server.Data;
using System.Net;

namespace PlntsDotCom.Server.Controllers
{
    [ApiController]
    [Route("api")]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductsController(ApplicationDbContext context) => _context = context;

        [HttpGet(Name = "GetProducts")]
        public List<Product> Get()
        {
            return _context.Products.ToList();
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public ActionResult<Product> GetProduct(int id) {

            var a = _context.Products.SingleOrDefault(m => m.Id == id);
            if (a is null)
            {
                return NotFound();
            }

            return a;
        }
    }
}
