using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Entity;

namespace Entity

{
    public class Course : BaseEntity
    {
        [Required]
        public string Title { get; set; } = default!;
        public string Language { get; set; } = "en";
        public string Level { get; set; } = "Beginner";
        public string SubTitle { get; set; } = string.Empty;
        public int Students { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0m;
        public string Instructor { get; set; } = string.Empty;
        public bool Published { get; set; } = false;
        public string Image { get; set; } = "https://learnify-assets.s3.amazonaws.com/Images/learnify.png";
        public decimal Rating { get; set; } = 0m;

        public ICollection<Requirement> Requirements { get; set; } = new List<Requirement>();
        public ICollection<Learning> Learnings { get; set; } = new List<Learning>();

        public Guid? CategoryId { get; set; }
        public Category? Category { get; set; }

        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        public ICollection<UserCourse> UserCourses { get; set; } = new List<UserCourse>();
        public ICollection<Section> Sections { get; set; } = new List<Section>();
    }
}
