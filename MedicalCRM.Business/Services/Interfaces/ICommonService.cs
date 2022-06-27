﻿using MedicalCRM.Business.Models;
using MedicalCRM.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Services.Interfaces {
    public interface ICommonService {
        Task<List<UserDTO>> GetDoctors();
        Task<List<BloodTypeDTO>> BloodTypes();
        Task<List<Disease>> GetDiseasesAsync();
        Task<List<PatientDTO>> GetPatients(int doctorId);
        Task<List<UserDTO>> GetDoctors(int patientId);
    }
}
