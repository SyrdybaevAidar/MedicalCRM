using MedicalCRM.DataAccess.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Entities.Configurations {
    public class DoctorUserConfiguration : IEntityTypeConfiguration<DoctorUser> {
        public void Configure(EntityTypeBuilder<DoctorUser> builder) {

            builder.HasOne(i => i.DoctorDetails)
            .WithOne()
            .HasForeignKey<DoctorUser>(i => i.DoctorDetailsId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Chats)
                .WithOne(x => x.Doctor)
                .HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Property(i => i.DoctorDetailsId)
                .HasColumnName("doctor_details_id")
                .HasColumnType("int")
                .IsRequired(false);
        }
    }
}
