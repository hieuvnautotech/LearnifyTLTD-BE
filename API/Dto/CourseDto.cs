// API/Dto/CourseDto.cs
using System;

namespace API.Dto
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public float Price { get; set; }
        public string Instructor { get; set; } = string.Empty;
        public decimal Rating { get; set; }
        public string Image { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }
}
