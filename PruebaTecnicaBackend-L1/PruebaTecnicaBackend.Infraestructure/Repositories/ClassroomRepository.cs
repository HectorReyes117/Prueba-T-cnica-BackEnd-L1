using Microsoft.EntityFrameworkCore;
using PruebaTecnicaBackend.Core.Entities;
using PruebaTecnicaBackend.Core.Interfaces;
using PruebaTecnicaBackend.Infraestructure.Data;

namespace PruebaTecnicaBackend.Infraestructure.Repositories
{
    public class ClassroomRepository : IClassroomRepository
    {

        private readonly PruebaTecnicaBackendContext _context;

        public ClassroomRepository(PruebaTecnicaBackendContext _context)
        {
            this._context = _context;
        }

        public async Task<bool> DeleteClassroom(int id)
        {      
            try
            {
                var entity = await _context.Classrooms.FindAsync(id);

                if (entity == null)
                {
                    return false;
                }

                await Task.FromResult(_context.Classrooms.Remove(entity));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<IEnumerable<Classroom>> GetClassroom()
        {
            var entity = await _context.Classrooms.ToListAsync();
            return entity;
        }

        public async Task<IEnumerable<Classroom>> GetClassroomId(string Classroom)
        {
            var entity = await _context.Classrooms.Where(x => x.Course == Classroom).ToListAsync();
            return entity;
        }

        public async Task<bool> InsertClassroom(Classroom entity)
        {
            if (entity == null)
            {
                return false;
            }

            try
            {     
                await _context.Classrooms.AddAsync(entity);
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
