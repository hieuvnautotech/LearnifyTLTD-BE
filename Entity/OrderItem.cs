using System;
using System.Collections.Generic;
using Entity;

namespace Learnify.Entity.Models
{
    public class OrderItem : BaseEntity
    {
        public Guid CourseId { get; set; }
        public Course? Course { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal UnitPrice { get; set; } = 0m;
    }
}
