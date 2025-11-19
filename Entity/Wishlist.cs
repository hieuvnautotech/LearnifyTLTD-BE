using System;
using Entity;

namespace Entity

{
    public class Wishlist : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid CourseId { get; set; }

        public Course? Course { get; set; }
        public DateTime AddedAt { get; set; } = DateTime.UtcNow;
    }
}
