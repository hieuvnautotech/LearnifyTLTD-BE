using Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICourseRepository
    {
        Task<IReadOnlyList<Course>> GetCoursesAsync();
        Task<Course> GetCourseByIdAsync(Guid id);
    }
}
