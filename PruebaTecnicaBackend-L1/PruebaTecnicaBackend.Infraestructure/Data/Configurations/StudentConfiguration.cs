using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaTecnicaBackend.Core.Entities;

namespace PruebaTecnicaBackend.Infraestructure.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");

            builder.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.HasOne(d => d.Classroom)
                .WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassroomId)
                .HasConstraintName("FK__Student__Classro__398D8EEE");
        }
    }
}
