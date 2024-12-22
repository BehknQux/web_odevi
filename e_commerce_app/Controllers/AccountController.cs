using System.Security.Claims;
using System.Text;
using e_commerce_app.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_app.Controllers;

public class AccountController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ApplicationDbContext _context;

    public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, ApplicationDbContext context)
    {
        _signInManager = signInManager;
        _context = context;
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult ForgotPassword()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
        {
            ViewBag.Error = "User not found.";
            return View();
        }
        
        if (user.PasswordHash != password)
        {
            ViewBag.Error = "Invalid password.";
            return View();
        }
        await _signInManager.SignInAsync(user, isPersistent: true);

        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login", "Account");
    }
    
    [HttpPost]
    [Route("password-reset/request")]
    public async Task<IActionResult> ForgotPasswordRequest(string email)
    {
        var apiUrl = $"http://localhost:8080/password-reset/request/{email}";
        using (var client = new HttpClient())
        {
            var content = new StringContent("", Encoding.UTF8, "application/json");

            // POST isteği gönder
            var response = await client.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Password reset instructions have been sent to your email address.";
            }
            else
            {
                ViewBag.Message = "There was an issue processing your request.";
            }
        }

        // İşlem tamamlandığında kullanıcıyı login sayfasına yönlendirelim
        return RedirectToAction("Login", "Account");
    }
}