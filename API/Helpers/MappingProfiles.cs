using AutoMapper;
using Entity;
using API.Dto;

namespace Infrastructure.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Category, CategoryDto>();
    }
}
