using System;
using Entity;

namespace Learnify.Entity.Models
{
    public class Review : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid CourseId { get; set; }
        public Course? Course { get; set; }
        public int Rating { get; set; } = 5; // 1..5
        public string Comment { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
