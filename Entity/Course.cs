using System;

namespace Entity
{
    public class Course : BaseEntity   // BaseEntity chứa Guid Id
    {
        public string Title { get; set; } = string.Empty;
        public string SubTitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public float Price { get; set; }
        public string Instructor { get; set; } = string.Empty;

        public decimal Rating { get; set; } = 0;
        public int Students { get; set; } = 0;

        public string Image { get; set; } =
            "https://learnify-assets.s3.amazonaws.com/Images/learnify.png";

        public string Level { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;

        public bool Published { get; set; } = false;

        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        // ✅ Quan hệ Category (Guid chuẩn sạch)
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
