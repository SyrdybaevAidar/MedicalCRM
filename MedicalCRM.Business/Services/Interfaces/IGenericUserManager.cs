using MedicalCRM.Business.Models;
using MedicalCRM.DataAccess.Entities.UserEntities;
using MedicalCRM.DataAccess.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Services.Interfaces {
    public interface IGenericUserManager<TUser> where TUser: User {
        Task<IdentityResult> RegisterAsync(UserDTO userDTO);
        Task<UserType> LoginAsync(string Inn, bool rememberMe);
        Task<UserType> LoginAsync(UserDTO userDTO, bool rememberMe);
        bool IsSignedIn(ClaimsPrincipal user);
    }
}
