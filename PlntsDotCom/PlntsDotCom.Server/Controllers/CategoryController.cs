using Microsoft.AspNetCore.Mvc;
using PlntsDotCom.Server.Data;
using System.Net;

namespace PlntsDotCom.Server.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context) => _context = context;

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public ActionResult<Category> GetCategory(int id) 
        {
            var a = _context.Categories.SingleOrDefault(c => c.Id == id);
            if (a is null)
            {
                return NotFound();
            }

            return a;
        }

        [HttpGet("children/{categoryName}")]
        public List<Category> GetChildCategories(string categoryName) 
        {
            int parentCategoryId = _context.Categories
                                    .Where(c => c.Name == categoryName)
                                    .Select(c => c.Id)
                                    .SingleOrDefault();
            var categories = _context.Categories
                                    .Where (c => c.ParentCategoryId == parentCategoryId)
                                    .ToList();
            return categories;
        }
    }
}
