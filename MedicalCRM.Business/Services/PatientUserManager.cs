using AutoMapper;
using MedicalCRM.Business.Models;
using MedicalCRM.Business.Services.Interfaces;
using MedicalCRM.Business.UOWork;
using MedicalCRM.DataAccess.Entities.UserEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Services {
    public class PatientManager : GenericUserManager<PatientUser>, IPatientManager {
        private readonly IUnitOfWork _uow;
        public PatientManager(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IUnitOfWork uow) : base(userManager, signInManager, mapper, uow) {
            _uow = uow;
        }

        public async Task<PatientUser> GetByUserNameAsync(string userName) {
            var user = await _uow.Patients.All.Where(i => i.UserName == userName).FirstOrDefaultAsync();
            return user;
        }

        public async Task<PatientUser> GetById(int id) {
            var user = await _uow.Patients.All.Where(i => i.Id == id).FirstOrDefaultAsync();
            return user;
        }

        public async Task UpdateUserAsync(PatientUser patientUser) {
            await _userManager.AddToRoleAsync(patientUser, "Patient");
            _uow.Patients.Update(patientUser);
            await _uow.SaveChangesAsync();
        }
    }
}
