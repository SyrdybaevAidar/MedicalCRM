using MedicalCRM.DataAccess.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Services.Interfaces {
    public interface IDoctorManager: IGenericUserManager<DoctorUser> {
        Task<DoctorUser> GetById(int Id);

        Task Update(DoctorUser user);
    }
}
