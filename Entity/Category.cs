using System.Collections.Generic;

namespace Entity
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
