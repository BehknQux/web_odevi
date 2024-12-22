using Microsoft.AspNetCore.Mvc;
using e_commerce_app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_app.Controllers;

[Authorize]
public class HomeController : Controller
{
        public IActionResult Index()
        {
            return View();
        }
}