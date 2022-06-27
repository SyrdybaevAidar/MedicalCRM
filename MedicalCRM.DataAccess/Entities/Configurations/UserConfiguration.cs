using MedicalCRM.DataAccess.Entities.UserEntities;
using MedicalCRM.DataAccess.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Entities.Configurations {
    internal class UserConfiguration : IEntityTypeConfiguration<User> {
        public void Configure(EntityTypeBuilder<User> builder) {
            builder.HasDiscriminator(i => i.UserType)
                .HasValue<User>(UserType.User)
                .HasValue<DoctorUser>(UserType.Doctor)
                .HasValue<PatientUser>(UserType.Patient)
                .HasValue<AdminUser>(UserType.Admin)
                .IsComplete(true);

            builder.Property(i => i.BirthDate)
                .HasColumnName("birth_date")
                .HasColumnType("TIMESTAMP")
                .IsRequired();

            builder.Property(i => i.UserType)
                .HasColumnName("user_type")
                .HasColumnType("varchar(10)")
                .HasConversion<string>()
                .IsRequired();
        }
    }
}
