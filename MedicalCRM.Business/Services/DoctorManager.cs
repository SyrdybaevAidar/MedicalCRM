using AutoMapper;
using MedicalCRM.Business.Models;
using MedicalCRM.Business.Services.Interfaces;
using MedicalCRM.Business.UOWork;
using MedicalCRM.DataAccess.Entities.UserEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Services {
    public class DoctorManager : GenericUserManager<DoctorUser>, IDoctorManager {
        public DoctorManager(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IUnitOfWork unitOf) : base(userManager, signInManager, mapper, unitOf) {
        }

        public async Task DoctorRegister() { }

        public async Task<DoctorUser> GetById(int Id) {
            return await _uow.Doctors.GetByIdAsync(Id);
        }

        public async Task Update(DoctorUser user) {
            _uow.Doctors.Update(user);
            await _uow.SaveChangesAsync();
        }

        public override async Task<IdentityResult> RegisterAsync(UserDTO userDTO) {
            var result = await base.RegisterAsync(userDTO);
            var doctor = await _userManager.FindByNameAsync(userDTO.UserName);
            await _userManager.AddToRoleAsync(doctor, "Doctor");
            return result;
        }

        public async Task ChangePassword(int userId, string password) {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, token, password);
        }
    }
}
