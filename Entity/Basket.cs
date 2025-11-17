using System;
using System.Collections.Generic;
using Entity;

namespace Learnify.Entity.Models
{
    public class Basket : BaseEntity
    {
        public Guid BuyerId { get; set; }
        public ICollection<BasketItem> Items { get; set; } = new List<BasketItem>();
        public string? PaymentIntentId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    
}
