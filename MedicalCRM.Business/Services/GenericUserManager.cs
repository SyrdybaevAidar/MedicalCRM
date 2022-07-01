using AutoMapper;
using MedicalCRM.Business.Models;
using MedicalCRM.Business.Services.Interfaces;
using MedicalCRM.Business.UOWork;
using MedicalCRM.DataAccess.Entities.UserEntities;
using MedicalCRM.DataAccess.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Services {
    public class GenericUserManager<TUser>: IGenericUserManager<TUser> where TUser: User {
        protected readonly UserManager<User> _userManager;
        protected readonly SignInManager<User> _signInManager;
        protected readonly IUnitOfWork _uow;
        protected IMapper _mapper;

        public GenericUserManager(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IUnitOfWork unitOf) {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _uow = unitOf;
        }

        public async Task<IdentityResult> RegisterAsync(UserDTO userDTO) {
            var entity = _mapper.Map<TUser>(userDTO);
            var doctorCount = _uow.Doctors.All.Count();
            var patientCount = _uow.Patients.All.Count();
            var adminCount = _uow.Admins.All.Count();
            entity.Id = doctorCount + patientCount + adminCount + 1;
            entity.CreateDateTime = DateTime.Now;
            entity.IsActive = true;
            var result = await _userManager.CreateAsync(entity,  userDTO.Password);
            return result;
        }

        public async Task<UserType> LoginAsync(string inn, bool rememberMe) {
            var user = await _userManager.FindByNameAsync(inn);
            var result = await _signInManager.PasswordSignInAsync(user, "Test123!", rememberMe, lockoutOnFailure: false);
            if (!result.Succeeded) {
                return UserType.Unauthorized;
            }
            return user.UserType;
        }

        public async Task<UserType> LoginAsync(UserDTO userDTO, bool rememberMe) {
            var result = await _signInManager.PasswordSignInAsync(userDTO.UserName, userDTO.Password, rememberMe, lockoutOnFailure: false);
            if (!result.Succeeded) {
                return UserType.Unauthorized;
            }
            var user = await _userManager.FindByNameAsync(userDTO.UserName);
            return user.UserType;
        }

        public bool IsSignedIn(ClaimsPrincipal user) {
            return _signInManager.IsSignedIn(user);
        }
    }
}
