using System.Linq;
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

            CreateMap<StudyingYear, StudyingYearResource>();
            CreateMap<StudyingYearResource, StudyingYear>()
                .ForMember(s => s.Id, opt => opt.Ignore());

            CreateMap<StudentClass, StudentClassResource>().ReverseMap();

            //lookups
            CreateMap<Grade, GradeResource>().ReverseMap();
            CreateMap<Material, MaterialResource>().ReverseMap();

            CreateMap<Semester, SemesterResource>();
            CreateMap<SemesterResource, Semester>()
                .ForMember(sr => sr.Id, opt => opt.Ignore());

            //class module
            CreateMap<Class, ClassResource>()
                .ForMember(c => c.Students, opt => opt.MapFrom(cr => cr.Students.Select(c => c.StudentId)));

            CreateMap<ClassResource, Class>()
                .ForMember(c => c.Id, opt => opt.Ignore())
                .ForMember(c => c.Students, opt => opt.Ignore())
                .AfterMap((cr, c) =>
                {
                    var removedStudents = c.Students.Where(clas => !cr.Students.Contains(clas.StudentId)).ToList();
                    foreach (var s in removedStudents)
                        c.Students.Remove(s);

                    var addedStudents = cr.Students.Where(id => !c.Students.Any(s => s.StudentId == id)).Select(id => new StudentClass { StudentId = id, ClassId = c.Id }).ToList();
                    foreach (var clsStd in addedStudents)
                        c.Students.Add(clsStd);
                });
        }
    }
}