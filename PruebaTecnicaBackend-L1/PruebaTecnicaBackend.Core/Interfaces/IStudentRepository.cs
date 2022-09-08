using PruebaTecnicaBackend.Core.Entities;

namespace PruebaTecnicaBackend.Core.Interfaces
{
    public interface  IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudent();
        Task<IEnumerable<Student>> GetStudentId(string Student);
        Task<bool> InsertStudent(Student entity);
        Task<bool> DeleteStudent(int id);
    }
}
