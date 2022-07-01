using MedicalCRM.DataAccess.Contexts;
using MedicalCRM.DataAccess.Entities.UserEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess {
    public static class DbContextRegister {
        public static void AddDbContext(this IServiceCollection services, string connectionString) {
            services.AddDbContextPool<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));

            services
                .AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole<int>>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
        }
    }
}
