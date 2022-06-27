using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Entities.Configurations {
    public class DiseaseConfiguration : IEntityTypeConfiguration<Disease> {
        public void Configure(EntityTypeBuilder<Disease> builder) {
            builder.ToTable("disease");

            builder.HasKey(x => x.Id);

            builder.HasMany(i => i.Consultations)
                .WithOne(i => i.Disease)
                .HasForeignKey(i => i.DiseaseId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Property(i => i.Id)
                .HasColumnName("int");

            builder.Property(i => i.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(500)")
                .IsRequired(true);
        }
    }
}
