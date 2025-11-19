using System;
using Entity;

namespace Entity

{
    public class Coupon : BaseEntity
    {
        public string Code { get; set; } = default!;
        public decimal DiscountPercent { get; set; } = 0m;
        public DateTime? ExpireAt { get; set; }
        public bool Active { get; set; } = true;
    }
}
