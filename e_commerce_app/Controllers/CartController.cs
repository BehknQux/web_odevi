using e_commerce_app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]  // User authentication is required for accessing this controller
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        // Constructor initializes database context and user manager
        public CartController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet("GetCartItems")]
        public async Task<IActionResult> GetCartItems()
        {
            var user = await _userManager.GetUserAsync(User); // Get currently logged-in user
            if (user == null)
            {
                return Unauthorized("User not authenticated."); // If user is not logged in, return unauthorized
            }

            var userId = user?.Id;

            // Retrieve cart items associated with the user
            var cartItems = await _context.CartItems
                .Where(ci => ci.UserId == userId) // Filter by user ID
                .Include(ci => ci.Product) // Include product details for each cart item
                .Select(ci => new
                {
                    ci.Product.Name, // Product name
                    ci.Product.Price, // Product price
                    ci.Quantity, // Quantity in cart
                    ci.Product.Id // Product ID
                }).ToListAsync();

            if (!cartItems.Any())
            {
                return NotFound("No items found in your cart."); // If cart is empty, return a 404 response
            }

            return Ok(cartItems); // Return cart items in response
        }

        [HttpPost("AddToCart")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart([FromForm] int productId)
        {
            var user = await _userManager.GetUserAsync(User); // Get current user information
            if (user == null)
            {
                return Unauthorized("User not authenticated.");
            }

            var userId = user?.Id;

            // Check if the product already exists in the user's cart
            var existingCartItem = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.UserId == userId && ci.ProductId == productId);

            if (existingCartItem != null)
            {
                // If item exists, increment the quantity
                existingCartItem.Quantity++;
                _context.CartItems.Update(existingCartItem); // Mark as updated
            }
            else
            {
                // If item doesn't exist, create a new cart item
                var newCartItem = new CartItem
                {
                    ProductId = productId,
                    Quantity = 1,
                    UserId = userId
                };
                _context.CartItems.Add(newCartItem); // Add new item to database
            }

            await _context.SaveChangesAsync(); // Commit changes to database

            return RedirectToAction("Index", "Product"); // Redirect to product listing page
        }

        [HttpPost("RemoveFromCart")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveFromCart([FromForm] int productId)
        {
            var user = await _userManager.GetUserAsync(User); // Get current user information
            if (user == null)
            {
                return Unauthorized("User not authenticated.");
            }

            var userId = user?.Id;

            // Check if the product exists in the user's cart
            var existingCartItem = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.UserId == userId && ci.ProductId == productId);

            if (existingCartItem != null)
            {
                if (existingCartItem.Quantity > 1)
                {
                    // Decrease the quantity if it's greater than 1
                    existingCartItem.Quantity--;
                    _context.CartItems.Update(existingCartItem); // Mark as updated
                }
                else
                {
                    // Remove the item if quantity is 1
                    _context.CartItems.Remove(existingCartItem); // Mark as removed
                }

                await _context.SaveChangesAsync(); // Commit changes to database
            }

            return RedirectToAction("Index", "Product"); // Redirect to product listing page
        }
    }
}
