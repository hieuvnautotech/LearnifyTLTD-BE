using System;
using Entity;

namespace Learnify.Entity.Models
{
    public class Wishlist : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid CourseId { get; set; }

        public Course? Course { get; set; }
        public DateTime AddedAt { get; set; } = DateTime.UtcNow;
    }
}
