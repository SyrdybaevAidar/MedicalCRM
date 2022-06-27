using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Entities.Configurations {
    public class BloodTypeConfiguration : IEntityTypeConfiguration<BloodType> {
        public void Configure(EntityTypeBuilder<BloodType> builder) {
            builder.ToTable("blood_type");

            builder.HasKey(x => x.Id);

            builder.Property(i => i.Id)
                .HasColumnType("int")
                .HasColumnName("id");

            builder.Property(i => i.Type)
                .HasColumnType("int")
                .HasColumnName("type")
                .IsRequired(true);

            builder.Property(i => i.RhesusFactore)
                .HasColumnType("int")
                .HasColumnName("rhesus_factore")
                .HasConversion<int>()
                .IsRequired();
        }
    }
}
