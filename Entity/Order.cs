using System;
using System.Collections.Generic;
using Entity;

namespace Learnify.Entity.Models
{
    public class Order : BaseEntity
    {
        public Guid BuyerId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal Total { get; set; }
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
        public string PaymentIntentId { get; set; } = default!;
        public string Status { get; set; } = "Pending";
    }
}
