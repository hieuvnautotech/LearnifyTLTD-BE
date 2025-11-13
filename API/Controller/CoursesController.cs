using API.Dto;
using AutoMapper;
using Core.Interfaces;
using Core.Specifications;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly IGenericRepository<Course> _repo;
        private readonly IMapper _mapper;


        public CoursesController(IGenericRepository<Course> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
public async Task<ActionResult<IReadOnlyList<CourseDto>>> GetCourses(
    string? search, int? categoryId, string? sort = "title", int pageIndex = 1, int pageSize = 5)
{
    var skip = (pageIndex - 1) * pageSize;
    var spec = new CourseWithCategorySpecification(search?.ToLower(), categoryId, sort, skip, pageSize);

    var countSpec = new CourseWithCategorySpecification(search?.ToLower(), categoryId, sort, 0, int.MaxValue);

    var totalItems = await _repo.CountAsync(countSpec);
    var courses = await _repo.ListAsync(spec);
    var data = _mapper.Map<IReadOnlyList<CourseDto>>(courses);

    return Ok(new
    {
        pageIndex,
        pageSize,
        totalItems,
        data
    });
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
