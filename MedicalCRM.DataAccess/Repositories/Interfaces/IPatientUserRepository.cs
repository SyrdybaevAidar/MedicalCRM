using MedicalCRM.DataAccess.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Repositories.Interfaces {
    public interface IPatientUserRepository: IRepository<PatientUser> {
        Task<PatientUser?> GetByIdWithNavigations(int id);
    }
}
