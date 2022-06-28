using AutoMapper;
using MedicalCRM.Business.Models;
using MedicalCRM.Business.Services.Interfaces;
using MedicalCRM.Business.UOWork;
using MedicalCRM.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalCRM.Business.Services {
    public class CommonService: ICommonService {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public CommonService(IUnitOfWork uow, IMapper mapper) {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<List<UserDTO>> GetDoctors() {
            return _mapper.Map<List<UserDTO>>(await _uow.Doctors.GetAllAsync());
        }

        public async Task<List<BloodTypeDTO>> BloodTypes() {
            return _mapper.Map<List<BloodTypeDTO>>(await _uow.BloodTypes.GetAllAsync());
        }

        public async Task<List<Disease>> GetDiseasesAsync() {
            return await _uow.Diseases.GetAllAsync();
        }

        public async Task<List<PatientDTO>> GetPatients(int doctorId, string Inn, int count = 0) {
            var result = _uow.Patients.All.Where(i => i.DoctorUserId == doctorId && (i.UserName.Contains(Inn ?? "")));

            if (count > 0) {
                result.Take(count);
            };
            return _mapper.Map<List<PatientDTO>>(await result.ToListAsync());
        }

        public async Task<List<UserDTO>> GetDoctors(int patientId) {
            var patient = await _uow.Patients.GetByIdAsync(patientId);
            var result = await _uow.Doctors.All.Where(i => i.Id == patient.DoctorUserId).ToListAsync();
            return _mapper.Map<List<UserDTO>>(result);
        }
    }
}
