using MedicalCRM.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Seeds {
    public class MedicamentSeeds : IEntityTypeConfiguration<Medicament> {
        public void Configure(EntityTypeBuilder<Medicament> builder) {
            builder.HasData(new Medicament[] { 
                new Medicament(){ 
                    Id = 1,
                    Name = "Цитрамон",
                    Price = 5
                },
                new Medicament(){
                    Id = 2,
                    Name = "Парацетамол",
                    Price = 5
                }
            } );
        }
    }
}
