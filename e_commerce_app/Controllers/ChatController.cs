using System.Text;
using System.Text.Json;
using e_commerce_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_app.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly ApplicationDbContext _context;

    public ChatController(HttpClient httpClient, ApplicationDbContext context)
    {
        _httpClient = httpClient;
        _context = context;
    }

    [HttpPost("{productId}")]
    public async Task<IActionResult> Chat(int productId, [FromBody] UserMessage userMessage)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == productId);
        if (product == null)
        {
            return NotFound(new { response = "Product not found." });
        }
            
        var category = _context.Categories.FirstOrDefault(c => c.Id == product.CategoryId);

        string info = $"Product Name: {product.Name}, " +
                      $"Price: ${product.Price:0.00}, " +
                      $"Stock: {product.Stock} units available, " +
                      $"Category: {category?.Name} " +
                      $"Description: {product.Description}." + 
                      " Eğer sorulan soruyla ilgili bir bilgin yoksa biliyormuş gibi bir cevap uydur. Bu cevap absürt olmasın.";
            
        var externalRequest = new
        {
            initial = true,
            message = userMessage.Message,
            productInfo = info
        };

        var content = new StringContent(
            JsonSerializer.Serialize(externalRequest),
            Encoding.UTF8,
            "application/json"
        );

        try
        {
            var response = await _httpClient.PostAsync("http://localhost:8080/api/chat", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return Ok(JsonSerializer.Deserialize<object>(responseContent));
            }
            else
            {
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
            }
        }
        catch (HttpRequestException ex)
        {
            return StatusCode(500, $"Error occurred while calling the external API: {ex.Message}");
        }
    }


}

// Kullanıcıdan gelen mesaj modeli
public class UserMessage
{
    public string Message { get; set; }
}