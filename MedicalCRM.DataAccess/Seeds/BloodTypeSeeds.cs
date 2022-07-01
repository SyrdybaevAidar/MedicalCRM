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
                    Name = "1-положительная"
                },
                new(){
                    Id = 2,
                    Name = "2-положительная"
                },
                new(){
                    Id = 3,
                    Name = "3-положительная"
                },
                new(){
                    Id = 4,
                    Name = "4-положительная"
                },
                new(){
                    Id = 1,
                    Name = "1-отрицательная"
                },
                new(){
                    Id = 2,
                    Name = "2-отрицательная"
                },
                new(){
                    Id = 3,
                    Name = "3-отрицательная"
                },
                new(){
                    Id = 4,
                    Name = "4-отрицательная"
                }
            });

        }
    }
}
