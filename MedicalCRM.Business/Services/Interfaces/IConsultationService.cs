using MedicalCRM.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Services.Interfaces {
    public interface IConsultationService {
        Task AddConsultation(ConsultationDTO dto);
        Task EditConsultation(ConsultationDTO consultation);
        Task<ConsultationDTO?> GetConsultationById(int Id);
        Task<List<ConsultationDTO>> GetByPatientId(int patientId, int count = 0);
        Task<List<ConsultationDTO>> GetByDoctorId(int doctorId, int count = 0);
    }
}
