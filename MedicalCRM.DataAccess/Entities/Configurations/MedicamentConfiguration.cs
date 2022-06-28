using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Entities.Configurations {
    public class MedicamentConfiguration : IEntityTypeConfiguration<Medicament> {
        public void Configure(EntityTypeBuilder<Medicament> builder) {
            builder.ToTable("medicament");

            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.ReceptByMedicaments)
                .WithOne(x => x.Medicament)
                .HasForeignKey(x => x.Id)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
