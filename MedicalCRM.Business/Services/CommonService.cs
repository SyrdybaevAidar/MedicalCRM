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

        public async Task<FilterResult> GetPatients(PatientFilterDTO filter) {
            var query = _uow.Patients.All
                .Where(i => i.UserName.Contains(filter.Inn ?? ""))
                .Where(i => i.Name.Contains(filter.Name ?? ""))
                .Where(i => i.Surname.Contains(filter.Surname ?? ""))
                .Where(i => i.Patronimic.Contains(filter.Patronimic ?? ""))
                .Where(i => filter.BirthDateEnd == null || i.BirthDate < filter.BirthDateEnd)
                .Where(i => filter.BirthDateStart == null || i.BirthDate > filter.BirthDateStart)
                .Where(i => filter.DoctorId == null ||  i.DoctorUserId == filter.DoctorId)
                .Skip(filter.PageSize * (filter.Page - 1)).Take(filter.PageSize)
                .OrderBy(i => i.UserName);

            var count = await query.CountAsync();
            var users = _mapper.Map<List<UserDTO>>(await query.ToListAsync());
            return new() { 
                Users = users,
                TotalItemCount = count
            };
        }

        public async Task<List<UserDTO>> GetDoctors(int patientId) {
            var patient = await _uow.Patients.GetByIdAsync(patientId);
            var result = await _uow.Doctors.All.Where(i => i.Id == patient.DoctorUserId).ToListAsync();
            return _mapper.Map<List<UserDTO>>(result);
        }
    }
}
