using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Seeds {
    public static class RoleSeeds {
        public static async Task Seed(this RoleManager<IdentityRole<int>> roleManager) {
            if ((await roleManager.FindByNameAsync("Admin") == null)) {
                await roleManager.CreateAsync(new IdentityRole<int>() { Name = "Admin"});
            }
            if ((await roleManager.FindByNameAsync("Patient") == null)) {
                await roleManager.CreateAsync(new IdentityRole<int>() { Name = "Patient" });
            }
            if ((await roleManager.FindByNameAsync("Doctor") == null)) {
                await roleManager.CreateAsync(new IdentityRole<int>() { Name = "Doctor" });
            }
        }
    }
}
