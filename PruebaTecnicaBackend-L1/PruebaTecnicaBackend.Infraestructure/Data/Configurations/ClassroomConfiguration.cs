using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaTecnicaBackend.Core.Entities;

namespace PruebaTecnicaBackend.Infraestructure.Data.Configurations
{
    public class ClassroomConfiguration : IEntityTypeConfiguration<Classroom>
    {
        public void Configure(EntityTypeBuilder<Classroom> builder)
        {
            builder.ToTable("Classroom");

            builder.Property(e => e.Course)
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
