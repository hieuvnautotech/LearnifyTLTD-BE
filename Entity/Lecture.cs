using System;
using System.ComponentModel.DataAnnotations;
using Entity;

namespace Learnify.Entity.Models
{
    public class Lecture : BaseEntity
    {
        [Required]
        public string Title { get; set; } = default!;

        public Guid SectionId { get; set; }
        public Section? Section { get; set; }

        public Guid CourseId { get; set; }
        public Course? Course { get; set; }

        public string? ContentUrl { get; set; }
        public TimeSpan? Duration { get; set; }
        public bool IsPreview { get; set; } = false;
        public int Order { get; set; } = 0;
    }
}
