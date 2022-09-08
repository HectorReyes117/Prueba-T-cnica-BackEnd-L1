namespace PruebaTecnicaBackend.Core.Entities
{
    public partial class ScheduleWeek
    {
        public int IdSchedule { get; set; }
        public int Dayss { get; set; }
        public string Weeks { get; set; } = null!;
        public string Months { get; set; } = null!;
        public int Years { get; set; }
        public int ProfessorId { get; set; }
        public virtual Professor Professor { get; set; } = null!;
    }
}
