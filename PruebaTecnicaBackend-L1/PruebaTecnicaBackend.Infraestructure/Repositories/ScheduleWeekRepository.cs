using PruebaTecnicaBackend.Core.DTO;
using PruebaTecnicaBackend.Core.Entities;
using PruebaTecnicaBackend.Core.Interfaces;
using PruebaTecnicaBackend.Infraestructure.Data;

namespace PruebaTecnicaBackend.Infraestructure.Repositories
{
    public class ScheduleWeekRepository : IScheduleWeekRepository
    {
        private readonly PruebaTecnicaBackendContext _context;

        public ScheduleWeekRepository(PruebaTecnicaBackendContext _context)
        {
            this._context = _context;
        }

        public async Task<bool> DeleteScheduleWeek(int id)
        {
            try
            {
                var entity = await _context.ScheduleWeeks.FindAsync(id);

                if (entity == null)
                {
                    return false;
                }

                await Task.FromResult(_context.ScheduleWeeks.Remove(entity));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<IEnumerable<ScheduleWeekGetDTO>> GetScheduleWeek()
        {
            var entity = await Task.FromResult(from scheduleweek in _context.ScheduleWeeks
                                               join professor in _context.Professors on scheduleweek.ProfessorId equals professor.ProfessorId
                                               select new ScheduleWeekGetDTO
                                               {
                                                   IdSchedule = scheduleweek.IdSchedule,
                                                   Dayss = scheduleweek.Dayss,
                                                   Weeks = scheduleweek.Weeks,
                                                   Months = scheduleweek.Months,
                                                   Years = scheduleweek.Years,
                                                   ProfessorId = scheduleweek.ProfessorId,

                                                   Professor = new ProfessorDTO
                                                   {
                                                        ProfessorId = professor.ProfessorId,
                                                        FirstName = professor.FirstName,
                                                        LastName = professor.LastName,
                                                        States = professor.States,
                                                        Turn = professor.Turn,
                                                        Matter = professor.Matter,
                                                        ClassroomId = professor.ClassroomId
    }
                                               });
            return entity;
        }

        public async Task<IEnumerable<ScheduleWeekGetDTO>> GetScheduleWeekDayMonthYear(int Day, string Month, int Year)
        {
            var entity = await Task.FromResult(from scheduleweek in _context.ScheduleWeeks.Where(x=> x.Dayss == Day && x.Months == Month && x.Years == Year)
                                               join professor in _context.Professors on scheduleweek.ProfessorId equals professor.ProfessorId
                                               select new ScheduleWeekGetDTO
                                               {
                                                   IdSchedule = scheduleweek.IdSchedule,
                                                   Dayss = scheduleweek.Dayss,
                                                   Weeks = scheduleweek.Weeks,
                                                   Months = scheduleweek.Months,
                                                   Years = scheduleweek.Years,
                                                   ProfessorId = scheduleweek.ProfessorId,

                                                   Professor = new ProfessorDTO
                                                   {
                                                       ProfessorId = professor.ProfessorId,
                                                       FirstName = professor.FirstName,
                                                       LastName = professor.LastName,
                                                       States = professor.States,
                                                       Turn = professor.Turn,
                                                       Matter = professor.Matter,
                                                       ClassroomId = professor.ClassroomId
                                                   }
                                               });
            return entity;
        }

        public async Task<IEnumerable<ScheduleWeekGetDTO>> GetScheduleWeekMonthYear(string Month, int Year)
        {
            var entity = await Task.FromResult(from scheduleweek in _context.ScheduleWeeks.Where(x => x.Months == Month && x.Years == Year)
                                               join professor in _context.Professors on scheduleweek.ProfessorId equals professor.ProfessorId
                                               select new ScheduleWeekGetDTO
                                               {
                                                   IdSchedule = scheduleweek.IdSchedule,
                                                   Dayss = scheduleweek.Dayss,
                                                   Weeks = scheduleweek.Weeks,
                                                   Months = scheduleweek.Months,
                                                   Years = scheduleweek.Years,
                                                   ProfessorId = scheduleweek.ProfessorId,

                                                   Professor = new ProfessorDTO
                                                   {
                                                       ProfessorId = professor.ProfessorId,
                                                       FirstName = professor.FirstName,
                                                       LastName = professor.LastName,
                                                       States = professor.States,
                                                       Turn = professor.Turn,
                                                       Matter = professor.Matter,
                                                       ClassroomId = professor.ClassroomId
                                                   }
                                               });
            return entity;
        }

        public async Task<IEnumerable<ScheduleWeekGetDTO>> GetScheduleWeek_WeekMonthYear(string Week, string Month, int Year)
        {
            var entity = await Task.FromResult(from scheduleweek in _context.ScheduleWeeks.Where(x => x.Weeks == Week && x.Months == Month && x.Years == Year)
                                               join professor in _context.Professors on scheduleweek.ProfessorId equals professor.ProfessorId
                                               select new ScheduleWeekGetDTO
                                               {
                                                   IdSchedule = scheduleweek.IdSchedule,
                                                   Dayss = scheduleweek.Dayss,
                                                   Weeks = scheduleweek.Weeks,
                                                   Months = scheduleweek.Months,
                                                   Years = scheduleweek.Years,
                                                   ProfessorId = scheduleweek.ProfessorId,

                                                   Professor = new ProfessorDTO
                                                   {
                                                       ProfessorId = professor.ProfessorId,
                                                       FirstName = professor.FirstName,
                                                       LastName = professor.LastName,
                                                       States = professor.States,
                                                       Turn = professor.Turn,
                                                       Matter = professor.Matter,
                                                       ClassroomId = professor.ClassroomId
                                                   }
                                               });
            return entity;
        }

        public async Task<bool> InsertScheduleWeek(ScheduleWeek entity)
        {

            if (entity == null)
            {
                return false;
            }

            try
            {
                await _context.ScheduleWeeks.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<bool> UpdateScheduleWeek(ScheduleWeek entity)
        {
            if (entity == null)
            {
                return false;
            }

            try
            {
                await Task.FromResult(_context.ScheduleWeeks.Update(entity));
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
