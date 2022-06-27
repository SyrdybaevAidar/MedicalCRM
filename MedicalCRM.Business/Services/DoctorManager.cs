using AutoMapper;
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
    }
}
