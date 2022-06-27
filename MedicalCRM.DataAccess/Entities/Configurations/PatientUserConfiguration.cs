using MedicalCRM.DataAccess.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Entities.Configurations {
    public class PatientUserConfiguration : IEntityTypeConfiguration<PatientUser> {
        public void Configure(EntityTypeBuilder<PatientUser> builder) {

            builder.HasMany(i => i.Consultations)
                .WithOne(i => i.Patient)
                .HasForeignKey(i => i.PatientId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.Chats)
                .WithOne(x => x.Patient)
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.DoctorUser)
                .WithOne()
                .HasForeignKey<PatientUser>(x => x.DoctorUserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.BloodType)
                .WithMany()
                .HasForeignKey(x => x.BloodTypeId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasIndex(x => x.DoctorUserId).IsUnique(false);

            builder.Property(x => x.DoctorUserId)
                .HasColumnName("doctor_id")
                .HasColumnType("int")
                .IsRequired(false);

            builder.Property(x => x.BloodTypeId)    
                .HasColumnName("blood_type_id")
                .HasColumnType("int")
                .IsRequired(false);

            builder.Property(x => x.Address)
                .HasColumnName("address")
                .HasColumnType("varchar(500)")
                .IsRequired(false);
        }
    }
}
