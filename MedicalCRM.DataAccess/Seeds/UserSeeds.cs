using MedicalCRM.DataAccess.Entities.UserEntities;
using MedicalCRM.DataAccess.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Seeds {
    public static class UserSeeds {
        public static async Task AddUserSeeds(this UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager) {

            await userManager.AddDoctorSeeds();
            await userManager.AddPatientSeeds(roleManager);
            await userManager.AddAdminSeeds();
        }
        public static async Task AddPatientSeeds(this UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager) {
            string[] WSurname = new string[5] { "Окубаева", "Айылчиева", "Куприна", "Арокина", "Седокина"};
            string[] HSurname = new string[5] { "Акынкаев", "Петров", "Куртаев", "Маасалиев", "Кыдыралев" };
            string[] Wname = new string[5] { "Наталья", "Сезим", "Светлана", "Алина", "Мээрим" };
            string[] Hname = new string[5] { "Айбек", "Сергей", "Кыдыр", "Марат", "Куттубек" };
            string[] WPatronimic = new string[2] { "Медеровна", "Кадыровна" };
            string[] HPatronimic = new string[2] { "Альбертович", "Медерович" };


            if ((await userManager.FindByNameAsync("12512201810213") == null)) {

                await userManager.CreateAsync(
                    new PatientUser() {
                        Id = 3,
                        CreateDateTime = DateTime.Now.ToUniversalTime(),
                        BirthDate = DateTime.Now,
                        Email = "asel.muzurotbek@gmail.com",
                        Name = "Акмат",
                        Surname = "Садыров",
                        Patronimic = "Кемелович",
                        Sex = Sex.Man,
                        UserName = "12512201810213",
                        DoctorUserId = 1
                    }, "Test123!");

                var user = await userManager.FindByNameAsync("12512201810213");
                await userManager.AddToRoleAsync(user, "Patient");
            }

            if ((await userManager.FindByNameAsync("12512201810214") == null)) {

                await userManager.CreateAsync(
                    new PatientUser() {
                        Id = 4,
                        CreateDateTime = DateTime.Now.ToUniversalTime(),
                        BirthDate = DateTime.Now,
                        Email = "asel.muzurotbek@gmail.com",
                        Name = "Бекназар",
                        Surname = "Акматов",
                        Patronimic = "Медерович",
                        Sex = Sex.Man,
                        UserName = "12512201810214",
                        DoctorUserId = 2
                    }, "Test123!");

                var user = await userManager.FindByNameAsync("12512201810214");
                await userManager.AddToRoleAsync(user, "Patient");
            }
        }

        public static async Task AddDoctorSeeds(this UserManager<User> userManager) {
            if ((await userManager.FindByNameAsync("AigulSultanovna")) == null) {
                await userManager.CreateAsync(
                    new DoctorUser() {
                        Id = 1,
                        CreateDateTime = DateTime.Now.ToUniversalTime(),
                        BirthDate = DateTime.Now,
                        Email = "DoctorTestUser@mail.ru",
                        Name = "Айгуль",
                        Surname = "Султанова",
                        Patronimic = "Кубатовна",
                        Sex = Sex.Woman,
                        UserName = "AigulSultanovna",
                    }, "Test123!");
                var user = await userManager.FindByNameAsync("AigulSultanovna");
                await userManager.AddToRoleAsync(user, "Doctor");
            }

            if ((await userManager.FindByNameAsync("KanymkylUsrailovna") == null)) {

                await userManager.CreateAsync(
                    new DoctorUser() {
                        Id = 2,
                        CreateDateTime = DateTime.Now.ToUniversalTime(),
                        BirthDate = DateTime.Now,
                        Email = "DoctorTestUser1@mail.ru",
                        Name = "Канымкуль",
                        Surname = "Саткынова",
                        Patronimic = "Исраиловна",
                        Sex = Sex.Woman,
                        UserName = "KanymkylUsrailovna",
                    }, "Test123!");

                var user = await userManager.FindByNameAsync("KanymkylUsrailovna");
                await userManager.AddToRoleAsync(user, "Doctor");
            }
        }

        public static async Task AddAdminSeeds(this UserManager<User> userManager) {
            if ((await userManager.FindByNameAsync("Admin")) == null) {
                await userManager.CreateAsync(
                    new AdminUser() {
                        Id = 5,
                        CreateDateTime = DateTime.Now.ToUniversalTime(),
                        BirthDate = DateTime.Now,
                        Email = "AdminTestUser@mail.ru",
                        Name = "Администратор",
                        Surname = "",
                        Patronimic = "",
                        Sex = Sex.Man,
                        UserName = "Admin",
                    }, "Test123!");
                var user = await userManager.FindByNameAsync("Admin");
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
