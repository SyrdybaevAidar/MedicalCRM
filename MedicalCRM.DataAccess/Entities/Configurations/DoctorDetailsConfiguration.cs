using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Entities.Configurations {
    public class DoctorDetailsConfiguration : IEntityTypeConfiguration<DoctorDetails> {
        public void Configure(EntityTypeBuilder<DoctorDetails> builder) {
            builder.ToTable("doctor_details");

            builder.HasKey(x => x.Id);

            builder.Property(i => i.Id)
                .HasColumnType("int")
                .HasColumnName("id");

            builder.HasOne(i => i.Position)
                .WithMany()
                .HasForeignKey(i => i.Position)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(i => i.PositionId)
                .HasColumnType("int")
                .HasColumnName("position_id")
                .IsRequired();

            builder.Property(i => i.DoctorId)
                .HasColumnType("int")
                .HasColumnName("doctor_id")
                .IsRequired();
        }
    }
}
