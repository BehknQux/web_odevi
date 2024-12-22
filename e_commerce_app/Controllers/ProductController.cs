using e_commerce_app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_app.Controllers;

[Authorize]
public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;
    private readonly ApplicationDbContext _context;

    public ProductController(ILogger<ProductController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var products = _context.Products.ToList(); 
        return View(products);
    }
    
    [HttpGet]
    [Route("Product/{id:int}")]
    public IActionResult Details(int id)
    {
        var product = _context.Products
            .Include(p => p.Category) 
            .FirstOrDefault(p => p.Id == id);

        return View(product);
    }
    
    [HttpGet]
    public IActionResult CreateOrEdit(int? id)
    {
        var categories = _context.Categories.ToList();
        if (id == null)
        {
            ViewBag.Categories = categories;
            return View(new Product());
        }
        else
        {

            var product = _context.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
            ViewBag.Categories = categories;
            return View(product);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateOrEdit(Product product)
    {
        if (product.Id == 0)
        {
            _context.Products.Add(product);
        }
        else
        {
            _context.Products.Update(product);
        }

        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);

        _context.Products.Remove(product);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddToCart(int productId)
    {
        string userId = "1";
 
        var existingCartItem = _context.CartItems
            .FirstOrDefault(ci => ci.ProductId == productId && ci.UserId == userId);

        if (existingCartItem != null)
        {
            existingCartItem.Quantity ++;
            _context.CartItems.Update(existingCartItem);
        }
        else
        {
            var cartItem = new CartItem
            {
                UserId = userId,
                ProductId = productId,
                Quantity = 1
            };
            _context.CartItems.Add(cartItem);
        }

        _context.SaveChanges();
        return RedirectToAction("Index");
    }

}