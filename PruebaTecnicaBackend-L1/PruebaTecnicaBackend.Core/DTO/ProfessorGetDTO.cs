namespace PruebaTecnicaBackend.Core.DTO
{
    public class ProfessorGetDTO
    {
        public int ProfessorId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string States { get; set; } = null!;
        public string? Turn { get; set; }
        public string? DateCrete { get; set; }
        public string? DateDelete { get; set; }
        public string Matter { get; set; } = null!;
        public int? ClassroomId { get; set; }
    }
}
