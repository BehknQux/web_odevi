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

    // Constructor to initialize HttpClient and ApplicationDbContext
    public ChatController(HttpClient httpClient, ApplicationDbContext context)
    {
        _httpClient = httpClient;
        _context = context;
    }

    [HttpPost("{productId}")]
    public async Task<IActionResult> Chat(int productId, [FromBody] UserMessage userMessage)
    {
        // Retrieve product details from the database based on the provided productId
        var product = _context.Products.FirstOrDefault(p => p.Id == productId);
        if (product == null)
        {
            // If the product is not found, return a 404 response
            return NotFound(new { response = "Product not found." });
        }
            
        // Retrieve category details for the product
        var category = _context.Categories.FirstOrDefault(c => c.Id == product.CategoryId);

        // Construct detailed product information to send to the external chat API
        string info = $"Product Name: {product.Name}, " +
                      $"Price: ${product.Price:0.00}, " +
                      $"Stock: {product.Stock} units available, " +
                      $"Category: {category?.Name} " +
                      $"Description: {product.Description}." + 
                      " If you do not have specific knowledge about the question, create a believable response instead of leaving it blank.";
            
        // Create the payload to send to the external API
        var externalRequest = new
        {
            initial = true,
            message = userMessage.Message, // The user's message
            productInfo = info // Product information to provide context
        };

        // Serialize the payload into JSON format
        var content = new StringContent(
            JsonSerializer.Serialize(externalRequest),
            Encoding.UTF8,
            "application/json"
        );

        try
        {
            // Send the payload to the external chat API
            var response = await _httpClient.PostAsync("http://localhost:8080/api/chat", content);

            if (response.IsSuccessStatusCode)
            {
                // If the API call is successful, deserialize and return the response
                var responseContent = await response.Content.ReadAsStringAsync();
                return Ok(JsonSerializer.Deserialize<object>(responseContent));
            }
            else
            {
                // Return the error response from the external API if it fails
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
            }
        }
        catch (HttpRequestException ex)
        {
            // Handle exceptions that occur during the HTTP request
            return StatusCode(500, $"Error occurred while calling the external API: {ex.Message}");
        }
    }
}

// Model to represent the user's message
public class UserMessage
{
    public string Message { get; set; } // The message content sent by the user
}
