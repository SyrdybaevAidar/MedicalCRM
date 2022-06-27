using AutoMapper;
using MedicalCRM.Business.Services.Interfaces;
using MedicalCRM.DataAccess.Entities.UserEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Services {
    public class DoctorManager : GenericUserManager<DoctorUser>, IDoctorManager {
        public DoctorManager(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper) : base(userManager, signInManager, mapper) {
        }
    }
}
