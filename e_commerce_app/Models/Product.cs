using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Validation için gerekli

namespace e_commerce_app.Models;

public class Product
{
    public int Id { get; set; } // Ürün ID

    [Required(ErrorMessage = "Ürün adı zorunludur.")]
    [StringLength(100, ErrorMessage = "Ürün adı en fazla 100 karakter olabilir.")]
    public string Name { get; set; } = string.Empty;// Ürün Adı

    [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
    public string Description { get; set; } = string.Empty;// Ürün Açıklaması

    [Required(ErrorMessage = "Fiyat zorunludur.")]
    [Range(0.01, 10000, ErrorMessage = "Fiyat 0.01 ile 10,000 arasında olmalıdır.")]
    public decimal Price { get; set; } // Ürün Fiyatı

    [Required(ErrorMessage = "Stok miktarı zorunludur.")]
    [Range(0, int.MaxValue, ErrorMessage = "Stok miktarı negatif olamaz.")]
    public int Stock { get; set; } // Stok Miktarı

    [Required(ErrorMessage = "Kategori ID zorunludur.")]
    public int CategoryId { get; set; } // Kategori ID

    [NotMapped]
    public Category Category { get; set; } // İlişki için navigasyon özelliği
}