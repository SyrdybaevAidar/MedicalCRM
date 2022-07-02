using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Entities.Configurations {
    public class ReceptConfiguration : IEntityTypeConfiguration<Recept> {
        public void Configure(EntityTypeBuilder<Recept> builder) {
            builder.ToTable("recept");

            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Medicaments)
                .WithOne(x => x.Recept)
                .HasForeignKey(x => x.ReceptId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
