using MedicalCRM.DataAccess.Entities.UserEntities.ChatEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Entities.Configurations.ChatEntityConfigurations {
    public class ChatConfiguration : IEntityTypeConfiguration<Chat> {
        public void Configure(EntityTypeBuilder<Chat> builder) {
            builder.ToTable("chat");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Patient)
                .WithMany(x => x.Chats)
                .HasForeignKey(i => i.PatientId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Doctor)
                .WithMany(x => x.Chats)
                .HasForeignKey(i => i.DoctorId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(i => i.Messages)
                .WithOne(i => i.Chat)
                .HasForeignKey(i => i.ChatId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(i => i.Id)
                .HasColumnName("id")
                .HasColumnType("int");

            builder.Property(i => i.PatientId)
                .HasColumnName("patient_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(i => i.DoctorId)
                .HasColumnName("doctor_id")
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
