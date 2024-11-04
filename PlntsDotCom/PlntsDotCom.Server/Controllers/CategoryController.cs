using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet("parentCategories")]
        public List<Category> GetParentCategories()
        {  
            var categories = _context.Categories
                .Where(c => c.ParentCategoryId == null)
                .ToList();

            return categories;
        }

        [HttpPost("add-child-category")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Category), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddChildCategory([FromBody] Category childCategory)
        {
            // Check if the model state is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if the ParentCategoryId exists in the database
            if (childCategory.ParentCategoryId.HasValue)
            {
                var parentCategory = await _context.Categories.FindAsync(childCategory.ParentCategoryId.Value);
                if (parentCategory == null)
                {
                    return BadRequest("Invalid Parent Category ID.");
                }
            }

            // Create a new child category object to add to the database
            var newChildCategory = new Category
            {
                Name = childCategory.Name,
                ParentCategoryId = childCategory.ParentCategoryId // Set the ParentCategoryId if provided
            };

            try
            {
                // Add the new child category to the context and save changes
                await _context.Categories.AddAsync(newChildCategory);
                await _context.SaveChangesAsync();

                // Return a 201 Created response with the newly created child category
                return CreatedAtAction(nameof(GetCategory), new { id = newChildCategory.Id }, newChildCategory);
            }
            catch (DbUpdateException dbEx)
            {
                // Log the error (consider using a logging framework)
                return StatusCode(500, new { message = "Database error occurred.", details = dbEx.InnerException?.Message });
            }
            catch (Exception ex)
            {
                // Log the exception message
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }

    }
}
