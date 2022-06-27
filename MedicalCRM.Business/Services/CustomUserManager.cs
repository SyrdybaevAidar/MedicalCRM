using AutoMapper;
using MedicalCRM.Business.Services.Interfaces;
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
        public CustomUserManager(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper) : base(userManager, signInManager, mapper) {
        }

        public async Task<UserType> GetUserTypeById(int id) {
            return (await _userManager.FindByIdAsync(id.ToString())).UserType;
        }
    }
}
