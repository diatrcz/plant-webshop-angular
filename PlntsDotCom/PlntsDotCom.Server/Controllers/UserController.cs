using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlntsDotCom.Server.Data;
using PlntsDotCom.Server.Models;
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
        private readonly UserManager<User> _userManager;
        public UserController(ApplicationDbContext context, SignInManager<User> signInManager, UserManager<User> userManager) {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    // Address = model.Address,
                    Type = UserType.LoggedInUser
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return Ok(new { Message = "Registration successful!!!!" });
                }

                var errors = result.Errors.Select(e => e.Description).ToList();
                return BadRequest(result.Errors);
            }

            return BadRequest(ModelState);
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

            return Ok();
        }
    }
}
