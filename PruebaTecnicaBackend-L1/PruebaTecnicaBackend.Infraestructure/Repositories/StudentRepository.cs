using Microsoft.EntityFrameworkCore;
using PruebaTecnicaBackend.Core.Entities;
using PruebaTecnicaBackend.Core.Interfaces;
using PruebaTecnicaBackend.Infraestructure.Data;

namespace PruebaTecnicaBackend.Infraestructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly PruebaTecnicaBackendContext _context;

        public StudentRepository(PruebaTecnicaBackendContext _context)
        {
            this._context = _context;
        }
        public async Task<IEnumerable<Student>> GetStudent()
        {
            var entity = await _context.Students.ToListAsync();
            return entity;
        }

        public async Task<IEnumerable<Student>> GetStudentId(string Student)
        {
            var entity = await _context.Students.Where(x => x.FirstName == Student).ToListAsync();
            return entity;
        }

        public async Task<bool> InsertStudent(Student entity)
        {
            if (entity == null)
            {
                return false;
            }

            try
            {
                var student = await _context.Students.Where(x => x.ClassroomId == entity.ClassroomId).ToListAsync();

                if (student.Count <= 29)
                {
                    await _context.Students.AddAsync(entity);
                    await _context.SaveChangesAsync();
                    return true; 
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteStudent(int id)
        {
            try
            {
                var entity = await _context.Students.FindAsync(id);

                if (entity == null)
                {
                    return false;
                }

                await Task.FromResult(_context.Students.Remove(entity));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
