using Core.Interfaces;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class CourseRepository : ICourseRepository
    {
        private readonly StoreContext _context;
        public CourseRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Course>> GetCoursesAsync()
        {
            return await _context.Courses
                .Include(x => x.Category)
                .ToListAsync();
        }

        public async Task<Course> GetCourseByIdAsync(Guid id)
        {
            return await _context.Courses
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
