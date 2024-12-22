using System.ComponentModel.DataAnnotations;

namespace e_commerce_app.Models;

public class Order
{
    public int Id { get; set; } // Sipariş ID

    [Required(ErrorMessage = "User ID zorunludur.")]
    public string UserId { get; set; } // Kullanıcı ID (Siparişi veren kullanıcı)

    [Required(ErrorMessage = "Order Date zorunludur.")]
    [DataType(DataType.DateTime, ErrorMessage = "Geçerli bir tarih formatı giriniz.")]
    public DateTime OrderDate { get; set; } // Sipariş Tarihi

    // Sipariş birden fazla sipariş detayına sahip olabilir
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}