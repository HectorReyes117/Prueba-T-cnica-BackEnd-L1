using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaTecnicaBackend.Core.Entities;

namespace PruebaTecnicaBackend.Infraestructure.Data.Configurations
{
    public class ScheduleWeekConfiguration : IEntityTypeConfiguration<ScheduleWeek>
    {
        public void Configure(EntityTypeBuilder<ScheduleWeek> builder)
        {
            builder.HasKey(e => e.IdSchedule)
                     .HasName("PK__Schedule__D16D3B627E8F87F9");

            builder.ToTable("ScheduleWeek");

            builder.Property(e => e.Months)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.Weeks)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.HasOne(d => d.Professor)
                .WithMany(p => p.ScheduleWeeks)
                .HasForeignKey(d => d.ProfessorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ScheduleW__Profe__59063A47");


        }
    }
}
