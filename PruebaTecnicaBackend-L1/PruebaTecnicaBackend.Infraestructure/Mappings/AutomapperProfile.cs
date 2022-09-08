using AutoMapper;
using PruebaTecnicaBackend.Core.DTO;
using PruebaTecnicaBackend.Core.Entities;

namespace PruebaTecnicaBackend.Infraestructure.Mappings
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Classroom, ClassroomDTO>();
            CreateMap<ClassroomDTO, Classroom>();
            CreateMap<Student, StudentDTO>();
            CreateMap<StudentDTO, Student>();
            CreateMap<Professor, ProfessorDTO>();
            CreateMap<ProfessorDTO, Professor>();
            CreateMap<ProfessorGetDTO, Professor>();
            CreateMap<Professor, ProfessorGetDTO>();
            CreateMap<ScheduleWeek, ScheduleWeekDTO>();
            CreateMap<ScheduleWeekDTO, ScheduleWeek>();
        }
    }
}
