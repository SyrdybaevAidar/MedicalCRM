using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Entities.Configurations {
    internal class ConsultationDiseaseConfiguration : IEntityTypeConfiguration<ConsultationDisease> {
        public void Configure(EntityTypeBuilder<ConsultationDisease> builder) {
            builder.ToTable("consultation_by_disaeses");

            builder.HasKey(x => x.Id);

            builder.HasOne(i => i.Consultation)
                .WithMany(i => i.ChronicalDiseases)
                .HasForeignKey(i => i.ConsultationId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(i => i.Disease)
                .WithMany(i => i.Consultations)
                .HasForeignKey(i => i.DiseaseId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
