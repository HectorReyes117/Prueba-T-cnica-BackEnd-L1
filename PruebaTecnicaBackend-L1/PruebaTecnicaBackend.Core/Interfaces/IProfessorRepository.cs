using PruebaTecnicaBackend.Core.Entities;

namespace PruebaTecnicaBackend.Core.Interfaces
{
    public interface IProfessorRepository
    {
        Task<IEnumerable<Professor>> GetProfessor();
        Task<IEnumerable<Professor>> GetProfessorId(string Name);
        Task<bool> InsertProfessor(Professor entity);
        Task<bool> DeleteProfessor(int id);
    }
}
