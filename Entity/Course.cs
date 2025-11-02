using System;
using System.Collections.Generic;

namespace Entity
{
    public class Course : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Instructor { get; set; }
        public decimal Rating { get; set; }
        public string Image { get; set; } = "https://learnify-assets.s3.amazonaws.com/Images/learnify.png";
        public string Level { get; set; }
        public string Language { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    }
}
