namespace PruebaTecnicaBackend.Core.Entities
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int? ClassroomId { get; set; }

        public virtual Classroom? Classroom { get; set; }
    }
}
