using PruebaTecnicaBackend.Core.Entities;

namespace PruebaTecnicaBackend.Core.Interfaces
{
    public interface IClassroomRepository
    {
        Task<IEnumerable<Classroom>> GetClassroom();
        Task<IEnumerable<Classroom>> GetClassroomId(string Classroom);
        Task<bool> InsertClassroom(Classroom entity);
        Task<bool> DeleteClassroom(int id);
    }
}
