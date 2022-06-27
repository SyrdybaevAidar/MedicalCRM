using AutoMapper;
using MedicalCRM.Business.Models;
using MedicalCRM.Business.Services.Interfaces;
using MedicalCRM.Business.UOWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Services {
    public class PatientService : BaseService, IPatientService {
        public PatientService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) {
        }

        public async Task<List<DoctorDTO>> GetDoctors(int Id) {
            var entities = await _uow.Doctors.GetAllAsync();
            return _mapper.Map<List<DoctorDTO>>(entities);
        }

        public async Task<PatientDTO> GetPatient(int Id) {
            var entity = await _uow.Patients.GetByIdWithNavigations(Id);
            return _mapper.Map<PatientDTO>(entity);
        }
    }
}
