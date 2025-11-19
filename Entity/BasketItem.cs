using System;
using System.Collections.Generic;
using Entity;

namespace Entity

{
    public class BasketItem : BaseEntity
    {
        public Guid CourseId { get; set; }
        public Course? Course { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal UnitPrice { get; set; } = 0m;
    }
}
