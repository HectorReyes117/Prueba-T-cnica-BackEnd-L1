namespace PruebaTecnicaBackend.Core.Entities
{
    public partial class Professor
    {
        public Professor()
        {
            ScheduleWeeks = new HashSet<ScheduleWeek>();
        }

        public int ProfessorId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string States { get; set; } = null!;
        public string Turn { get; set; } = null!;
        public string DateCrete { get; set; } = null!;
        public string? DateDelete { get; set; }
        public string Matter { get; set; } = null!;
        public int? ClassroomId { get; set; }

        public virtual Classroom? Classroom { get; set; }
        public virtual ICollection<ScheduleWeek> ScheduleWeeks { get; set; }
    }
}
