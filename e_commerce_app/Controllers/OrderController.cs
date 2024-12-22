using e_commerce_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_app.Controllers;

public class OrderController : Controller
{
    private readonly ApplicationDbContext _context;

    public OrderController(ApplicationDbContext context)
    {
        _context = context;
    }

    // 1. Sipariş Listeleme
    public IActionResult Index()
    {
        var userId = "1";
        var orders = _context.Orders
            .Where(o => o.UserId == userId)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .ToList();
        return View(orders);
    }

    // 2. Sipariş Oluşturma (GET)
    [HttpGet]
    public IActionResult Create()
    {
        var userId = "1"; // Statik kullanıcı ID

        // Kullanıcının sepet bilgilerini alıyoruz
        var cartItems = _context.CartItems
            .Where(c => c.UserId == userId)
            .Include(c => c.Product)
            .ToList();

        // Eğer sepet boşsa kullanıcıyı uyarıyoruz
        if (!cartItems.Any())
        {
            TempData["ErrorMessage"] = "Your cart is empty. Add products to your cart before ordering.";
            return RedirectToAction("Index", "Cart");
        }

        return View(cartItems); // CartItems model olarak gönderiliyor
    }



    // 3. Sipariş Oluşturma (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(DateTime date)
    {
        var userId = "1"; // Statik kullanıcı ID

        // Kullanıcının sepet bilgilerini alıyoruz
        var cartItems = _context.CartItems
            .Where(c => c.UserId == userId)
            .Include(c => c.Product)
            .ToList();

        if (!cartItems.Any())
        {
            TempData["ErrorMessage"] = "Your cart is empty. Add products to your cart before ordering.";
            return RedirectToAction("Index", "Product");
        }

        // Sipariş oluşturma
        var newOrder = new Order
        {
            UserId = userId,
            OrderDate = DateTime.SpecifyKind(date, DateTimeKind.Utc), // Tarihi UTC'ye çevir
            OrderItems = cartItems.Select(c => new OrderItem
            {
                ProductId = c.ProductId,
                Quantity = c.Quantity,
                Price = c.Product.Price
            }).ToList()
        };

        _context.Orders.Add(newOrder);
        _context.CartItems.RemoveRange(cartItems); // Sepeti temizle
        _context.SaveChanges();

        TempData["SuccessMessage"] = "Your order has been successfully placed!";
        return RedirectToAction("Index", "Order");
    }



    // 4. Sipariş Detayları (GET)
    [HttpGet]
    public IActionResult Details(int id)
    {
        var order = _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .FirstOrDefault(o => o.Id == id);

        if (order == null)
        {
            return NotFound();
        }

        return View(order);
    }

    // 5. Sipariş Güncelleme (GET)
    [HttpGet]
    public IActionResult Update(int id)
    {
        var order = _context.Orders
            .Include(o => o.OrderItems)
            .FirstOrDefault(o => o.Id == id);

        if (order == null)
        {
            return NotFound();
        }

        ViewBag.Products = _context.Products.ToList();
        return View(order);
    }

    // 6. Sipariş Güncelleme (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(Order order, List<int> productIds, List<int> quantities)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Products = _context.Products.ToList();
            return View(order);
        }

        var existingOrder = _context.Orders
            .Include(o => o.OrderItems)
            .FirstOrDefault(o => o.Id == order.Id);

        if (existingOrder == null)
        {
            return NotFound();
        }

        // Mevcut sipariş detaylarını kaldırıyoruz
        _context.OrderItems.RemoveRange(existingOrder.OrderItems);

        // Yeni sipariş detaylarını ekliyoruz
        for (int i = 0; i < productIds.Count; i++)
        {
            var product = _context.Products.Find(productIds[i]);
            if (product != null)
            {
                existingOrder.OrderItems.Add(new OrderItem
                {
                    ProductId = product.Id,
                    Quantity = quantities[i],
                    Price = product.Price
                });
            }
        }

        existingOrder.OrderDate = DateTime.Now;
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    // 7. Sipariş Silme
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var order = _context.Orders
            .Include(o => o.OrderItems)
            .FirstOrDefault(o => o.Id == id);

        if (order == null)
        {
            return NotFound();
        }

        _context.OrderItems.RemoveRange(order.OrderItems); // Sipariş detaylarını sil
        _context.Orders.Remove(order); // Siparişi sil
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}
