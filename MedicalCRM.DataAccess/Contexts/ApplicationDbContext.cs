using MedicalCRM.DataAccess.Entities.Configurations;
using MedicalCRM.DataAccess.Entities.Configurations.ChatEntityConfigurations;
using MedicalCRM.DataAccess.Entities.UserEntities;
using MedicalCRM.DataAccess.Seeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedicalCRM.DataAccess.Context {
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int> {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PatientUserConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorUserConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new BloodTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BloodTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ChatConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new ReceptByMedicamentConfiguration());
            modelBuilder.ApplyConfiguration(new ReceptConfiguration());

            modelBuilder.ApplyConfiguration(new PositionSeeds());
            modelBuilder.ApplyConfiguration(new BloodTypeSeeds());

            base.OnModelCreating(modelBuilder);
        }
    }
}