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

    // Constructor to initialize logger and database context
    public ProductController(ILogger<ProductController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    // Display a list of products
    public IActionResult Index()
    {
        // Retrieve all products ordered by ID
        var products = _context.Products.OrderBy(p => p.Id).ToList(); 
        return View(products);
    }
    
    [HttpGet]
    [Route("Product/{id:int}")]
    public IActionResult Details(int id)
    {
        // Retrieve a single product by its ID and include its category details
        var product = _context.Products
            .Include(p => p.Category) 
            .FirstOrDefault(p => p.Id == id);

        return View(product);
    }
    
    [HttpGet]
    public IActionResult CreateOrEdit(int? id)
    {
        // Retrieve all categories for the dropdown
        var categories = _context.Categories.ToList();

        if (id == null)
        {
            // Create a new product if no ID is provided
            ViewBag.Categories = categories;
            return View(new Product());
        }
        else
        {
            // Edit an existing product by its ID
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
            // Add a new product to the database
            _context.Products.Add(product);
        }
        else
        {
            // Update an existing product
            _context.Products.Update(product);
        }

        // Save changes to the database
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        // Find the product by ID
        var product = _context.Products.FirstOrDefault(p => p.Id == id);

        // Remove the product from the database
        if (product != null) _context.Products.Remove(product);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}
