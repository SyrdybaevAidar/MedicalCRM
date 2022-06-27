using MedicalCRM.DataAccess.Entities.UserEntities.ChatEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Entities.Configurations.ChatEntityConfigurations {
    public class MessageConfiguration : IEntityTypeConfiguration<Message> {
        public void Configure(EntityTypeBuilder<Message> builder) {
            builder.ToTable("message");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Chat)
                .WithMany(x => x.Messages)
                .HasForeignKey(i => i.ChatId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(i => i.Id)
                .HasColumnName("id")
                .HasColumnType("int");

            builder.Property(i => i.UserId)
                .HasColumnName("user_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(i => i.ChatId)
                .HasColumnName("chat_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Text)
                .HasColumnType("varchar(700)")
                .HasColumnName("text")
                .IsRequired(true);

            builder.Property(i => i.SendDate)
                .HasColumnName("send_date")
                .HasColumnType("TIMESTAMP")
                .IsRequired();

            builder.Property(i => i.IsRead)
                .HasColumnName("is_read")
                .HasColumnType("boolean")
                .HasDefaultValue(false);
        }
    }
}
