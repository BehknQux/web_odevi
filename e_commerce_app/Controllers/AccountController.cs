using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_app.Controllers;

public class AccountController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountController(SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager;
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
        var result = await _signInManager.PasswordSignInAsync(email, password, false, false);

        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Home");
        }

        ViewBag.Error = "Invalid email or password.";
        return View();
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