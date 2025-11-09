// Infrastructure/Helpers/MappingProfiles.cs
using AutoMapper;
using Entity;
using API.Dto;

namespace Infrastructure.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Course, CourseDto>()
                .ForMember(d => d.Category, o => o.MapFrom(s => s.Category != null ? s.Category.Name : string.Empty))
                .ForMember(d => d.Image, o => o.MapFrom(s => string.IsNullOrEmpty(s.Image) ? "https://learnify-assets.s3.amazonaws.com/Images/learnify.png" : s.Image));
        }
    }
}
