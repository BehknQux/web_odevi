using System.ComponentModel.DataAnnotations;

namespace e_commerce_app.Models;

public class CartItem
{
    public int Id { get; set; } // Sepet Öğesi ID

    [Required(ErrorMessage = "Kullanıcı ID zorunludur.")]
    public string? UserId { get; set; } // Kullanıcı ID

    [Required(ErrorMessage = "Ürün ID zorunludur.")]
    public int ProductId { get; set; } // Ürün ID

    public Product Product { get; set; } // İlişki için navigasyon özelliği

    [Required(ErrorMessage = "Ürün adedi zorunludur.")]
    [Range(1, int.MaxValue, ErrorMessage = "Ürün adedi 1 veya daha büyük olmalıdır.")]
    public int Quantity { get; set; } // Ürün Adedi
}