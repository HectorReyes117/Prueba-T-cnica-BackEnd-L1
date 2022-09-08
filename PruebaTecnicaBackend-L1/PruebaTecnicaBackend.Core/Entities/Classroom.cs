namespace PruebaTecnicaBackend.Core.Entities
{
    public partial class Classroom
    {
        public Classroom()
        {
            Professors = new HashSet<Professor>();
            Students = new HashSet<Student>();
        }

        public int ClassroomId { get; set; }
        public string Course { get; set; } = null!;
        public virtual ICollection<Professor> Professors { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
