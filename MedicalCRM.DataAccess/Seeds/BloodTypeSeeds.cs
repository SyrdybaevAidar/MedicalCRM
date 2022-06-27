using MedicalCRM.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Seeds {
    internal class BloodTypeSeeds : IEntityTypeConfiguration<BloodType> {
        public void Configure(EntityTypeBuilder<BloodType> builder) {
            builder.HasData(new BloodType[] {
                new(){ 
                    Id = 1,
                    RhesusFactore = Enums.RhesusFactor.Positive,
                    Type = 1
                },
                new(){
                    Id = 2,
                    RhesusFactore = Enums.RhesusFactor.Positive,
                    Type = 2
                },
                new(){
                    Id = 3,
                    RhesusFactore = Enums.RhesusFactor.Positive,
                    Type = 3
                },
                new(){
                    Id = 4,
                    RhesusFactore = Enums.RhesusFactor.Positive,
                    Type = 4
                }
            });

        }
    }
}
