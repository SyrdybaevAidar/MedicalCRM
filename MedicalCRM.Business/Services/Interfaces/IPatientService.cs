using MedicalCRM.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Services.Interfaces {
    public interface IPatientService {
        Task<PatientDTO> GetPatient(int Id);
        Task<List<DoctorDTO>> GetDoctors(int Id);
    }
}
