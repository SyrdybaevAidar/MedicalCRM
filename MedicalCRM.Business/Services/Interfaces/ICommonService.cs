using MedicalCRM.Business.Models;
using MedicalCRM.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Services.Interfaces {
    public interface ICommonService {
        Task<FilterResult> GetDoctors(PatientFilterDTO patient);
        Task<List<BloodTypeDTO>> BloodTypes();
        Task<FilterResult> GetPatients(PatientFilterDTO filterDTO);
        Task<List<UserDTO>> GetDoctors(int patientId);
        Task<List<UserDTO>> GetNewPatients();
        Task<List<UserDTO>> GetNewDoctors();
    }
}
