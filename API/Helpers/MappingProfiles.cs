using AutoMapper;
using API.Dtos.Course;
using API.Dtos.Category;
using Entity;

namespace API.MappingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Course, CourseDto>()
                .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category != null ? s.Category.Name : ""));
            
            CreateMap<Category, CategoryDto>();
        }
    }
}
