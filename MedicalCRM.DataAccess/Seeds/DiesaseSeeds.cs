using MedicalCRM.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Seeds {
    public class DiseaseSeeds : IEntityTypeConfiguration<Disease> {
        public void Configure(EntityTypeBuilder<Disease> builder) {
            builder.HasData(new Disease[] {
                new(){
                    Id = 1,
                    Name = "Гайморит",
                },
                new(){
                    Id = 2,
                    Name = "Ангина",
                }
            });
        }
    }
}
