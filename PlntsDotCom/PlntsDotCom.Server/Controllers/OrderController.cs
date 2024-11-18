using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlntsDotCom.Server.Data;
using PlntsDotCom.Server.Models;

namespace PlntsDotCom.Server.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        public OrderController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost("place")]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderModel orderModel)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

             var order = new Order
            {
                User = user,
                OrderDate = DateTime.UtcNow,
                StatusId = 1,
                OrderItems = orderModel.Items.Select(item => new OrderedItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                }).ToList()
            };

            var totalAmount = order.OrderItems.Sum(oi =>
                _context.Products.Find(oi.ProductId).Price * oi.Quantity);

            var invoice = new Invoice
            {
                Amount = totalAmount,
                InvoiceDate = DateTime.UtcNow
            };

            order.Invoice = invoice;

            foreach (var item in order.OrderItems)
            {
                var product = await _context.Products.FindAsync(item.ProductId);
                if (product.Stock < item.Quantity)
                    return BadRequest($"Insufficient stock for product {product.Name}");

                product.Stock -= item.Quantity;
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return Ok(new { OrderId = order.Id });
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<Order>> GetOrder(int orderId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            var order = await _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .Include(o => o.Invoice)
                .Include(o => o.Status)
                .FirstOrDefaultAsync(o => o.Id == orderId && o.User.Id == user.Id);

            if (order == null)
                return NotFound();

            return order;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .Include(o => o.Invoice)
                .Include(o => o.Status)
                .Where(o => o.User.Id == user.Id)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

            return orders;
        }

    }
}
