using System;
using System.Collections.Generic;

namespace Entity
{
    public class Category : BaseEntity   // BaseEntity: Guid Id
    {
        public string Name { get; set; } = string.Empty;

        // Một category có nhiều course
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
