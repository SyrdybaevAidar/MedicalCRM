using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Entities.Configurations {
    public class ReceptByMedicamentConfiguration : IEntityTypeConfiguration<ReceptByMedicament> {
        public void Configure(EntityTypeBuilder<ReceptByMedicament> builder) {
            builder.ToTable("recept_by_medicament");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.ReceptId)
                .IsUnique(false);

            builder.HasOne(x => x.Recept)
                .WithMany(x => x.Medicaments)
                .HasForeignKey(x => x.ReceptId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Property(x => x.Note)
                .HasColumnType("varchar(700)")
                .HasColumnName("note")
                .IsRequired();

            builder.Property(x => x.MedicamentName)
                .HasColumnType("varchar(700)")
                .HasColumnName("medicament_name")
                .IsRequired();

            builder.Property(x => x.Count)
                .HasColumnName("column")
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
