﻿using Microsoft.AspNetCore.Authentication;
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
                .Select(u => u.FirstName)
                .FirstOrDefault();

            if (userName == null)
            {
                return NotFound(); 
            }

            return Ok(new { userName }); 
        }

        [HttpGet("type")]
        public IActionResult GetUserType()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var userType = _context.Users
                .Where (u => u.Id == userId)
                .Select(u => u.Type)
                .FirstOrDefault();

            if (userType == null)
            {
                return NotFound();
            }

            return Ok(new { userType });
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUserInfo()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return NotFound();
            }

            var userInfo = new
            {
                FirstName = user.FirstName ?? "",
                LastName = user.LastName ?? "",
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber ?? "",
                Address = user.Address ?? "",
                TwoFactorEnabled = user.TwoFactorEnabled
            };

            return Ok(new { user = userInfo });
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserModel model)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            user.FirstName = model.FirstName ?? user.FirstName;
            user.LastName = model.LastName ?? user.LastName;
            user.PhoneNumber = model.PhoneNumber ?? user.PhoneNumber;
            user.Address = model.Address ?? user.Address;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return Ok(new { Message = "Profile updated successfully" });
            }

            return BadRequest(new { Errors = result.Errors.Select(e => e.Description) });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return Ok();
        }

        [HttpGet("wishlist")]
        public async Task<IActionResult> GetWishlist()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var wishlistItems = await _context.Wishlists
                .Include(w => w.Product)
                .Where(w => w.UserId == userId)
                .Select(w => new
                {
                    WishlistId = w.Id,
                    ProductId = w.ProductId,
                    w.Product.Name,
                    w.Product.Price,
                    w.Product.ImageUrl,
                    w.Product.Description,
                    AddedDate = w.AddedDate
                })
                .OrderByDescending(w => w.AddedDate)
                .ToListAsync();

            return Ok(wishlistItems);
        }

        // Add item to wishlist
        [HttpPost("wishlist/add/{productId}")]
        public async Task<IActionResult> AddToWishlist(int productId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            // Check if product exists
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound("Product not found");
            }

            // Check if already in wishlist
            var existingItem = await _context.Wishlists
                .FirstOrDefaultAsync(w => w.UserId == userId && w.ProductId == productId);

            if (existingItem != null)
            {
                return BadRequest("Item already in wishlist");
            }

            // Add to wishlist
            var wishlistItem = new Wishlist
            {
                UserId = userId,
                ProductId = productId,
                AddedDate = DateTime.UtcNow
            };

            _context.Wishlists.Add(wishlistItem);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Added to wishlist", WishlistId = wishlistItem.Id });
        }

        // Remove item from wishlist
        [HttpDelete("wishlist/remove/{productId}")]
        public async Task<IActionResult> RemoveFromWishlist(int productId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var wishlistItem = await _context.Wishlists
                .FirstOrDefaultAsync(w => w.UserId == userId && w.ProductId == productId);

            if (wishlistItem == null)
            {
                return NotFound("Item not found in wishlist");
            }

            _context.Wishlists.Remove(wishlistItem);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Removed from wishlist" });
        }

        // Optional: Check if item is in wishlist
        [HttpGet("wishlist/check/{productId}")]
        public async Task<IActionResult> CheckWishlistItem(int productId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var exists = await _context.Wishlists
                .AnyAsync(w => w.UserId == userId && w.ProductId == productId);

            return Ok(new { IsInWishlist = exists });
        }
    }
}
