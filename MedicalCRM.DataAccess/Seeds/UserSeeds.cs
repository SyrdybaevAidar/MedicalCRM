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


           await userManager.AddPatientSeeds(roleManager);
        }
        public static async Task AddPatientSeeds(this UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager) {
            string[] WSurname = new string[5] { "Окубаева", "Айылчиева", "Куприна", "Арокина", "Седокина"};
            string[] HSurname = new string[5] { "Акынкаев", "Петров", "Куртаев", "Маасалиев", "Кыдыралев" };
            string[] Wname = new string[5] { "Наталья", "Сезим", "Светлана", "Алина", "Мээрим" };
            string[] Hname = new string[5] { "Айбек", "Сергей", "Кыдыр", "Марат", "Куттубек" };
            string[] WPatronimic = new string[2] { "Медеровна", "Кадыровна" };
            string[] HPatronimic = new string[2] { "Альбертович", "Медерович" };

            //int counter = 1;
            //foreach (var patronimic in WPatronimic) {
            //    foreach (var surname in WSurname) {
            //        foreach (var name in Wname) {
            //            if ((await userManager.FindByIdAsync(counter.ToString())) == null) {

            //                var result = await userManager.CreateAsync(
            //                    new DoctorUser() {
            //                        Id = counter,
            //                        BirthDate = DateTime.Now,
            //                        Email = $"DoctorTestUser{counter}@mail.ru",
            //                        Name = name,
            //                        Surname = surname,
            //                        Patronimic = patronimic,
            //                        Sex = Sex.Woman,
            //                        UserName = $"DoctorTest{counter.ToString()}",
            //                    }, "Test123!");

            //                var user = await userManager.FindByNameAsync($"DoctorTest{counter}");
            //                await userManager.AddToRoleAsync(user, "Doctor");
            //            }
            //            counter++;
            //        }
            //    }
            //}

            //foreach (var patronimic in HPatronimic) {
            //    foreach (var surname in HSurname) {
            //        foreach (var name in Hname) {
            //            if ((await userManager.FindByIdAsync(counter.ToString())) == null) {

            //                var result = await userManager.CreateAsync(
            //                    new DoctorUser() {
            //                        Id = counter,
            //                        BirthDate = DateTime.Now,
            //                        Email = $"DoctorTestUser{counter}@mail.ru",
            //                        Name = name,
            //                        Surname = surname,
            //                        Patronimic = patronimic,
            //                        Sex = Sex.Man,
            //                        UserName = $"DoctorTest{counter.ToString()}",
            //                    }, "Test123!");

            //                var user = await userManager.FindByNameAsync($"DoctorTest{counter}");
            //                await userManager.AddToRoleAsync(user, "Doctor");

            //            }
            //            counter++;
            //        }
            //    }
            //}

            //if ((await userManager.FindByNameAsync("PatientTest")) == null) {

                
            //    var result = await userManager.CreateAsync(
            //        new PatientUser() {
            //            Id = 1,
            //            BirthDate = DateTime.Now,
            //            Email = "PatientTestUser@mail.ru",
            //            Name = "Березина",
            //            Surname = "Эльмира",
            //            Patronimic = "Пациент",
            //            Sex = Sex.Man,
            //            UserName = "PatientTest",
            //            BloodTypeId = 1,
            //            Address = "Московская 61"
            //        }, "Test123!");

            //    var user = await userManager.FindByNameAsync("PatientTest");
            //    await userManager.AddToRoleAsync(user, "Patient");

            //}

            //if ((await userManager.FindByNameAsync("PatientTest1") == null)) {

            //    await userManager.CreateAsync(
            //        new PatientUser() {
            //            Id = 3,
            //            BirthDate = DateTime.Now,
            //            Email = "PatientTestUser1@mail.ru",
            //            Name = "Садыров",
            //            Surname = "Акмат",
            //            Patronimic = "Пациент",
            //            Sex = Sex.Man,
            //            UserName = "PatientTest1",
            //        }, "Test123!");

            //    var user = await userManager.FindByNameAsync("PatientTest1");
            //    await userManager.AddToRoleAsync(user, "Patient");
            //}
        }

        //public static async Task AddDoctorSeeds(this UserManager<User> userManager) {
        //    if ((await userManager.FindByNameAsync("DoctorTest")) == null) {
        //    await userManager.CreateAsync(
        //        new DoctorUser() {
        //                Id = 2,
        //                BirthDate = DateTime.Now,
        //                Email = "DoctorTestUser@mail.ru",
        //                Name = "Петров",
        //                Surname = "Александр",
        //                Patronimic = "Доктор",
        //                Sex = Sex.Man,
        //                UserName = "DoctorTest",
        //        }, "Test123!");
        //        var user = await userManager.FindByNameAsync("DoctorTest");
        //        await userManager.AddToRoleAsync(user, "Doctor");
        //    }
            
        //    if ((await userManager.FindByNameAsync("DoctorTest1") == null)) {
                
        //        await userManager.CreateAsync(
        //            new DoctorUser() {
        //                Id = 4,
        //                BirthDate = DateTime.Now,
        //                Email = "DoctorTestUser1@mail.ru",
        //                Name = "Васильева",
        //                Surname = "Александра",
        //                Patronimic = "Доктор",
        //                Sex = Sex.Man,
        //                UserName = "DoctorTest1",
        //            }, "Test123!");

        //        var user = await userManager.FindByNameAsync("DoctorTest1");
        //        await userManager.AddToRoleAsync(user, "Doctor");
        //    }
        //}
    }
}
