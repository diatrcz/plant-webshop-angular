using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlntsDotCom.Server.Data;
using System.Security.Claims;

namespace PlntsDotCom.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<User> _signInManager;
        public UserController(ApplicationDbContext context, SignInManager<User> signInManager) {
            _context = context;
            _signInManager = signInManager;
        }

        [HttpGet("is-loggedin")]
        public IActionResult IsLoggedIn()
        {
            return Ok(true);
        }

        [HttpGet("name")]
        public IActionResult GetUserName()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var userName = _context.Users
                .Where(u => u.Id == userId)
                .Select(u => u.UserName)
                .FirstOrDefault();

            if (userName == null)
            {
                return NotFound(); 
            }

            return Ok(new { userName }); 
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            //await HttpContext.SignOutAsync();

            return Ok();
        }
    }
}
