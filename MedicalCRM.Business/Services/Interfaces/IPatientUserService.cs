using MedicalCRM.Business.Models;
using MedicalCRM.DataAccess.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Services.Interfaces {
    public interface IPatientManager: IGenericUserManager<PatientUser> {
        Task<PatientUser> GetByUserNameAsync(string userName);
        Task UpdateUserAsync(PatientUser patientUser);
        Task<PatientUser> GetById(int id);
    }
}
