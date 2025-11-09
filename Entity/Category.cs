// Entity/Category.cs
namespace Entity
{
    public class Category : BaseEntity // nếu BaseEntity của mày là Guid thì đổi lại; ở Learnify dùng int
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
