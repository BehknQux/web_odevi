using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerce_app.Models;

public class OrderItem
{
    public int Id { get; set; } // Sipariş Detay ID

    [Required(ErrorMessage = "Order ID zorunludur.")]
    public int OrderId { get; set; } // Sipariş ID

    public Order Order { get; set; } // İlişki için navigasyon özelliği

    [Required(ErrorMessage = "Product ID zorunludur.")]
    public int ProductId { get; set; } // Ürün ID

    public Product Product { get; set; } // İlişki için navigasyon özelliği

    [Required(ErrorMessage = "Quantity zorunludur.")]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity 1 veya daha büyük olmalıdır.")]
    public int Quantity { get; set; } // Ürün Adedi

    [Required(ErrorMessage = "Price zorunludur.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price 0.01 veya daha büyük olmalıdır.")]
    [Column(TypeName = "decimal(18,2)")] // Veritabanı tipi
    public decimal Price { get; set; } // Ürün Fiyatı
}