using MedicalCRM.Business.Models;
using MedicalCRM.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Services.Interfaces {
    public interface IDoctorService {
        Task<DoctorDTO?> GetDoctor(int id);
        Task AddForm();
        Task<List<UserDTO>> GetDoctors();
    }
}
