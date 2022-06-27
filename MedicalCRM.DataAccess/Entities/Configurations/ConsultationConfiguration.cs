using MedicalCRM.DataAccess.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Entities.Configurations {
    public class ConsultationConfiguration : IEntityTypeConfiguration<Consultation> {
        public void Configure(EntityTypeBuilder<Consultation> builder) {
            builder.ToTable("consultations");

            builder.HasKey(x => x.Id);

            builder.Property(i => i.Id)
                .HasColumnType("int")
                .HasColumnName("id");

            builder.HasOne(i => i.Patient)
                .WithMany()
                .HasForeignKey(i => i.PatientId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(i => i.Doctor)
                .WithMany()
                .HasForeignKey(i => i.DoctorId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(i => i.ChronicalDiseases)
                .WithOne(i => i.Consultation)
                .HasForeignKey(i => i.ConsultationId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Property(i => i.PatientId)
                .HasColumnType("int")
                .HasColumnName("patient_id")
                .IsRequired();

            builder.Property(i => i.Recommendations)
                .HasColumnType("varchar(700)")
                .HasColumnName("recommendations")
                .HasDefaultValue()
                .IsRequired(false);

            builder.Property(i => i.DoctorId)
                .HasColumnType("int")
                .HasColumnName("doctor_id")
                .IsRequired();


            builder.Property(i => i.Date)
                .HasColumnName("date")
                .HasColumnType("TIMESTAMP")
                .IsRequired();
        }
    }
}
