using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Entity;

namespace Entity

{
    public class Section : BaseEntity
    {
        [Required]
        public string Title { get; set; } = default!;

        public Guid CourseId { get; set; }
        public Course? Course { get; set; }

        public ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();
    }
}
