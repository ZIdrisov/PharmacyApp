using System.ComponentModel.DataAnnotations.Schema;

namespace ISApteka.Models
{
    public class OrderItem
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("order_id")]
        public int OrderId { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("product_name")]
        public string ProductName { get; set; } = string.Empty;

        [Column("price")]
        public decimal Price { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        // Навигационные свойства (для связей)
        public Order? Order { get; set; }
        public Product? Product { get; set; }
    }
}