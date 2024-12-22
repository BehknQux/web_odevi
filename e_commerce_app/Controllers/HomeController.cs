using Microsoft.AspNetCore.Mvc;
using e_commerce_app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_app.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

        public IActionResult Index()
        {
            var cartItems = _context.CartItems.Include(c => c.Product).ToList();
            ViewBag.CartItems = cartItems;
            return View();
        }
}