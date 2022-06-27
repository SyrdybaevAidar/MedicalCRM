using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Entities.Configurations {
    public class PositionConfiguration : IEntityTypeConfiguration<Position> {
        public void Configure(EntityTypeBuilder<Position> builder) {
            builder.ToTable("Position");

            builder.HasKey(x => x.Id);

            builder.Property(i => i.Id)
                .HasColumnName("int");

            builder.Property(i => i.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(500)")
                .IsRequired(true);
        }
    }
}
