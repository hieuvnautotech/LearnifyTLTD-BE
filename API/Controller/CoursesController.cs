using Core.Interfaces;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly IGenericRepository<Course> _repo;

        public CoursesController(IGenericRepository<Course> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Course>>> GetCourses()
        {
            var courses = await _repo.ListAllAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(Guid id)
        {
            var course = await _repo.GetByIdAsync(id);
            if (course == null) return NotFound();
            return Ok(course);
        }
    }
}
