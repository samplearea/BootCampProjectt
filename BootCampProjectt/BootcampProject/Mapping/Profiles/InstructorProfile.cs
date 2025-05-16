using AutoMapper;
using BootcampProject.Entities.Concrete;
using BootcampProject.Entities.DTOs;

namespace BootcampProject.Mapping.Profiles
{
    public class InstructorProfile : Profile
    {
        public InstructorProfile()
        {
            CreateMap<Instructor, InstructorDto>().ReverseMap();
        }
    }
}
