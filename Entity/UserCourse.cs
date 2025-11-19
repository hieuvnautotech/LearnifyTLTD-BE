using System;
using Entity;

namespace Entity

{
    public class UserCourse : BaseEntity
    {
        public Guid UserId { get; set; }    // Identity user Guid
        public Guid CourseId { get; set; }

        public Course? Course { get; set; }
        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;
        public bool Completed { get; set; } = false;
        public decimal Progress { get; set; } = 0m; // 0..100
    }
}
