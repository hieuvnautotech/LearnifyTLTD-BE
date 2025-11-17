namespace Learnify.Core.DTOs
{
    public class CreateCourseDto
    {
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
