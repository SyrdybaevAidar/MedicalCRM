using MedicalCRM.Business.Services;
using MedicalCRM.Business.Services.Interfaces;
using MedicalCRM.Business.UOWork;
using MedicalCRM.DataAccess;
using MedicalCRM.DataAccess.Context;
using MedicalCRM.DataAccess.Entities.UserEntities;
using MedicalCRM.DataAccess.Seeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business {
    public static class ServiceDIRegistration {
        public static void RegisterServices(this IServiceCollection services, string connectionString) {
            DbContextRegister.AddDbContext(services, connectionString);
            services.AddScoped<ICustomUserManager, CustomUserManager>();
            services.AddSingleton<IUserIdProvider, CustomUserIdProvider>();
            services.AddScoped<IPatientManager, PatientManager>();
            services.AddScoped<IDoctorManager, DoctorManager>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IConsultationService, ConsultationService>();
            services.AddScoped<ICommonService, CommonService>();
        }

        public static async Task AddSeeds(this IServiceScope services) {
            var roleManager = services.ServiceProvider.GetService<RoleManager<IdentityRole<int>>>();
            var userManager = services.ServiceProvider.GetService<UserManager<User>>();
            await roleManager.Seed();
            await userManager.AddUserSeeds(roleManager);
        }
    }
}
