using e_commerce_app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace e_commerce_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]  // Kullanıcı doğrulaması yapılacak
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        // UserManager, oturum açan kullanıcının bilgilerine ulaşmak için kullanılır
        public CartController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet("GetCartItems")]
        public async Task<IActionResult> GetCartItems()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized("User not authenticated.");
            }

            var userId = user?.Id;

            // Kullanıcıya ait sepetteki öğeleri getiriyoruz
            var cartItems = await _context.CartItems
                .Where(ci => ci.UserId == userId)  // Kullanıcı ID'sine göre filtreleme
                .Include(ci => ci.Product)
                .Select(ci => new
                {
                    ci.Product.Name,
                    ci.Product.Price,
                    ci.Quantity
                }).ToListAsync();

            if (!cartItems.Any())
            {
                return NotFound("No items found in your cart."); 
            }

            return Ok(cartItems);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId)
        {
            var user = await _userManager.GetUserAsync(User);

            var userId = user?.Id;

            var existingCartItem = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.UserId == userId && ci.ProductId == productId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity++;
                _context.CartItems.Update(existingCartItem);
            }
            else
            {
            Console.WriteLine("----------------");
            Console.WriteLine("----------------");
            Console.WriteLine(productId);
            Console.WriteLine("----------------");
            Console.WriteLine("----------------");
                var newCartItem = new CartItem
                {
                    ProductId = productId,
                    Quantity = 1,
                    UserId = userId
                };
                _context.CartItems.Add(newCartItem);
            }
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Product");
        }
    }
}
