using MedicalCRM.DataAccess.Entities.UserEntities.ChatEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Seeds {
    public class ChatSeeds : IEntityTypeConfiguration<Chat> {
        public void Configure(EntityTypeBuilder<Chat> builder) {
            
        }
    }
}
