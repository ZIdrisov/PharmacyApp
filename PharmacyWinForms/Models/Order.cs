using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace ISApteka.Models
{
    public enum OrderStatus
    {
        New = 0,
        Ready = 1,
        Issued = 2
    }

    public class Order
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("status")]
        public OrderStatus Status { get; set; }

        public List<OrderItem> Items { get; set; } = new();
    }
}