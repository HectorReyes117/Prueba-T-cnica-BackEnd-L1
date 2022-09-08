using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaTecnicaBackend.Core.Entities;

namespace PruebaTecnicaBackend.Infraestructure.Data.Configurations
{
    public class ProfessorConfiguration : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.ToTable("Professor");

            builder.Property(e => e.DateCrete)
                .HasMaxLength(60)
                .IsUnicode(false);

            builder.Property(e => e.DateDelete)
                .HasMaxLength(60)
                .IsUnicode(false);

            builder.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Matter)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.States)
                .HasMaxLength(60)
                .IsUnicode(false);

            builder.Property(e => e.Turn)
                .HasMaxLength(60)
                .IsUnicode(false);

            builder.HasOne(d => d.Classroom)
                .WithMany(p => p.Professors)
                .HasForeignKey(d => d.ClassroomId)
                .HasConstraintName("FK__Professor__Class__4D94879B");
        }
    }
}
