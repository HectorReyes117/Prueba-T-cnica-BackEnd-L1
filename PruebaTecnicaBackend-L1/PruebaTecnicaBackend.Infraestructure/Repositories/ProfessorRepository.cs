using Microsoft.EntityFrameworkCore;
using PruebaTecnicaBackend.Core.Entities;
using PruebaTecnicaBackend.Core.Interfaces;
using PruebaTecnicaBackend.Infraestructure.Data;

namespace PruebaTecnicaBackend.Infraestructure.Repositories
{
    public class ProfessorRepository:IProfessorRepository
    {
        private readonly PruebaTecnicaBackendContext _context;

        public ProfessorRepository(PruebaTecnicaBackendContext _context)
        {
            this._context = _context;
        }

        public async Task<IEnumerable<Professor>> GetProfessor()
        {
            var entity = await _context.Professors.ToListAsync();
            return entity;
        }
        public async Task<IEnumerable<Professor>> GetProfessorId(string Name)
        {
            var entity = await _context.Professors.Where(x => x.FirstName == Name).ToListAsync();
            return entity;
        }
        public async Task<bool> InsertProfessor(Professor entity)
        {
            if (entity == null)
            {
                return false;
            }

            try
            {
                var validateClassroom = await _context.Professors.FirstOrDefaultAsync(x=> x.ClassroomId == entity.ClassroomId && x.FirstName == entity.FirstName);
                
                if (validateClassroom == null)
                {
                    var validateClassroomAndTurn = await _context.Professors.FirstOrDefaultAsync(x => x.ClassroomId == entity.ClassroomId && x.Turn == entity.Turn);
                    if (validateClassroomAndTurn == null)
                    {
                        var validateFirtNameAndTurn = await _context.Professors.FirstOrDefaultAsync(x => x.FirstName == entity.FirstName && x.Turn == entity.Turn);

                        if (validateFirtNameAndTurn == null)
                        {
                            var dateAndTime = DateTime.Now;
                            var Date = string.Format(dateAndTime.ToShortDateString(), "dd/mm/yy");

                            var NewProfessor = new Professor
                            {
                                FirstName = entity.FirstName,
                                LastName = entity.LastName,
                                States = "Activo",
                                Turn = entity.Turn,
                                DateCrete = Date,
                                DateDelete = "Aun activo",
                                Matter = entity.Matter,
                                ClassroomId = entity.ClassroomId
                            };

                            await _context.Professors.AddAsync(NewProfessor);
                            await _context.SaveChangesAsync();
                            return true;   
                        }

                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
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
       

        public async Task<bool> DeleteProfessor(int id)
        {

            var entity = await _context.Professors.FirstOrDefaultAsync(x=> x.ProfessorId == id);

            if (entity == null)
            {
                return false;
            }

            try
            {
                var dateAndTime = DateTime.Now;
                var Date = string.Format(dateAndTime.ToShortDateString(), "dd/mm/yy");

                entity.States = "Inactivo";
                entity.DateDelete = Date;   

                await Task.FromResult(_context.Professors.Update(entity));
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
