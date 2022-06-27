using MedicalCRM.DataAccess.Entities.UserEntities;
using MedicalCRM.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Services.Interfaces {
    public interface ICustomUserManager: IGenericUserManager<User> {
        Task<UserType> GetUserTypeById(int id);
    }
}
