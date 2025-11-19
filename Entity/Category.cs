using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Entity;

namespace Entity

{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; } = default!;

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
