namespace PruebaTecnicaBackend.Core.DTO
{
    public class StudentDTO
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int? ClassroomId { get; set; }
    }
}
