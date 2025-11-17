using System;
using System.ComponentModel.DataAnnotations;
using Entity;

namespace Learnify.Entity.Models
{
    public class Requirement : BaseEntity
    {
        [Required]
        public string Name { get; set; } = default!;

        public Guid CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
