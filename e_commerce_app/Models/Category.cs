using System.ComponentModel.DataAnnotations;

namespace e_commerce_app.Models;

public class Category
{
    public int Id { get; set; } // Kategori ID

    [Required(ErrorMessage = "Kategori adı zorunludur.")]
    [StringLength(100, ErrorMessage = "Kategori adı en fazla 100 karakter olabilir.")]
    public string Name { get; set; } // Kategori Adı

    // İlişki: Bir kategori birden fazla ürüne sahip olabilir
    public ICollection<Product> Products { get; set; } = new List<Product>();
}