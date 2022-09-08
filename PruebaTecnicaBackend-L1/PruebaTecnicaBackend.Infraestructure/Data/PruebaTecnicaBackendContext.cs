using Microsoft.EntityFrameworkCore;
using PruebaTecnicaBackend.Core.Entities;
using PruebaTecnicaBackend.Infraestructure.Data.Configurations;

namespace PruebaTecnicaBackend.Infraestructure.Data
{
    public partial class PruebaTecnicaBackendContext : DbContext
    {
        public PruebaTecnicaBackendContext()
        {
        }

        public PruebaTecnicaBackendContext(DbContextOptions<PruebaTecnicaBackendContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Classroom> Classrooms { get; set; } = null!;
        public virtual DbSet<Professor> Professors { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClassroomConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessorConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
        }
    }
}
