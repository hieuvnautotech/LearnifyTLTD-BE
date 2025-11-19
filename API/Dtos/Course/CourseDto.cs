using System;

namespace API.Dtos.Course
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string SubTitle { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Instructor { get; set; } = default!;
        public decimal Price { get; set; }
        public decimal Rating { get; set; }
        public string Image { get; set; } = default!;
        public Guid? CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}
