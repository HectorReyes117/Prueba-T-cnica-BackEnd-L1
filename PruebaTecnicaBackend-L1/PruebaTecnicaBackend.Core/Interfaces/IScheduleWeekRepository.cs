using PruebaTecnicaBackend.Core.DTO;
using PruebaTecnicaBackend.Core.Entities;

namespace PruebaTecnicaBackend.Core.Interfaces
{
    public interface IScheduleWeekRepository
    {
        Task<IEnumerable<ScheduleWeekGetDTO>> GetScheduleWeek();
        Task<IEnumerable<ScheduleWeekGetDTO>> GetScheduleWeekDayMonthYear(int Day, string Month, int Year);
        Task<IEnumerable<ScheduleWeekGetDTO>> GetScheduleWeek_WeekMonthYear(string Week, string Month, int Year);
        Task<IEnumerable<ScheduleWeekGetDTO>> GetScheduleWeekMonthYear(string Month, int Year);
        Task<bool> InsertScheduleWeek(ScheduleWeek entity);
        Task<bool> DeleteScheduleWeek(int id);
        Task<bool> UpdateScheduleWeek(ScheduleWeek entity);
    }
}
