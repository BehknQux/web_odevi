using System.Text;
using System.Text.Json;
using e_commerce_app.Models;
using Microsoft.AspNetCore.Mvc;


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
            // Veritabanından ürün bilgilerini alın
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                return NotFound(new { response = "Product not found." });
            }

            // Başka bir API'ye gönderilecek veri modelini oluştur
            var externalRequest = new
            {
                initial = userMessage.Initial,
                message = userMessage.Message,
                productInfo = product.Description // Veritabanından alınan ürün açıklaması
            };

            // JSON içeriği oluştur
            var content = new StringContent(
                JsonSerializer.Serialize(externalRequest),
                Encoding.UTF8,
                "application/json"
            );

            try
            {
                // Başka bir API'ye POST isteği yap
                var response = await _httpClient.PostAsync("http://localhost:8080/api/chat", content);

                // API'den gelen cevabı işle
                if (response.IsSuccessStatusCode)
                { 
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return Ok(JsonSerializer.Deserialize<object>(responseContent));
                }
                else
                {
                    // Hata durumunda API cevabını döndür
                    return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
                }
            }
            catch (HttpRequestException ex)
            {
                // HTTP isteği sırasında bir hata oluşursa
                return StatusCode(500, $"Error occurred while calling the external API: {ex.Message}");
            }
        }

    }

// Kullanıcıdan gelen mesaj modeli
    public class UserMessage
    {
        public bool Initial { get; set; }
        public string Message { get; set; }
    }