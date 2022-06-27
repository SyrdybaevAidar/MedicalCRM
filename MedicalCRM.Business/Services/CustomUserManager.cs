using AutoMapper;
using MedicalCRM.Business.Services.Interfaces;
using MedicalCRM.Business.UOWork;
using MedicalCRM.DataAccess.Entities.UserEntities;
using MedicalCRM.DataAccess.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Services {
    public class CustomUserManager : GenericUserManager<User>, ICustomUserManager {
        public CustomUserManager(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IUnitOfWork unitOf) : base(userManager, signInManager, mapper, unitOf) {
        }

        public async Task<UserType> GetUserTypeById(int id) {
            return (await _userManager.FindByIdAsync(id.ToString())).UserType;
        }
    }
}
