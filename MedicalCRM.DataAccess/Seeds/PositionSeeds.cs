using MedicalCRM.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Seeds {
    public class PositionSeeds : IEntityTypeConfiguration<Position> {
        public void Configure(EntityTypeBuilder<Position> builder) {
            builder.HasData(new Position[] {
                new(){ 
                    Id = 1,
                    Name = "Врач терапевт",
                },
                new(){
                    Id = 2,
                    Name = "Хирург",
                }
            } );
        }
    }
}
