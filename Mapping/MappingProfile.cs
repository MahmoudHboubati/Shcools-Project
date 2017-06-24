using AutoMapper;
using vega.Controllers.Resources;
using vega.Models;

namespace vega.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentResource>().ReverseMap();

            CreateMap<StudentRegistration, StudentRegistrationResource>().ReverseMap();
        }
    }
}