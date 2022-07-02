using AutoMapper;
using MedicalCRM.Business.Models;
using MedicalCRM.Business.Services.Interfaces;
using MedicalCRM.Business.UOWork;
using MedicalCRM.DataAccess;
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
        public async Task<FilterResult> GetDoctors(PatientFilterDTO patient) {
            var users = await _uow.Doctors.GetFilteredPatientsQuery(_mapper.Map<UserFilterView>(patient));
            return new(users.Count, patient.Page, _mapper.Map<List<UserDTO>>(users.Users), patient.PageSize);
        }

        public async Task<List<BloodTypeDTO>> BloodTypes() {
            return _mapper.Map<List<BloodTypeDTO>>(await _uow.BloodTypes.GetAllAsync());
        }
        public async Task<List<UserDTO>> GetNewPatients() {
            var patients = await _uow.Patients.All.OrderByDescending(i => i.CreateDateTime).Take(5).ToListAsync();
            return _mapper.Map<List<UserDTO>>(patients);
        }

        public async Task<List<UserDTO>> GetNewDoctors() {
            var patients = await _uow.Doctors.All.OrderByDescending(i => i.CreateDateTime).Take(5).ToListAsync();
            return _mapper.Map<List<UserDTO>>(patients);
        }

        public async Task<FilterResult> GetPatients(PatientFilterDTO filter) {
            var query = _uow.Patients.All
                .Where(i => i.UserName.Contains(filter.Inn ?? ""))
                .Where(i => i.Name.Contains(filter.Name ?? ""))
                .Where(i => i.Surname.Contains(filter.Surname ?? ""))
                .Where(i => i.Patronimic.Contains(filter.Patronimic ?? ""))
                .Where(i => filter.BirthDateEnd == null || i.BirthDate < filter.BirthDateEnd)
                .Where(i => filter.BirthDateStart == null || i.BirthDate > filter.BirthDateStart)
                .Where(i => filter.DoctorId == null || i.DoctorUserId == filter.DoctorId);

            var count = await query.CountAsync();
            var users = await query.OrderBy(i => i.UserName)
                .Skip(filter.PageSize * (filter.Page - 1))
                .Take(filter.PageSize)
                .ToListAsync();
            var usersDto = _mapper.Map<List<UserDTO>>(users);
            return new(count, filter.Page, usersDto, filter.PageSize);
        }

        public async Task<List<UserDTO>> GetDoctors(int patientId) {
            var patient = await _uow.Patients.GetByIdAsync(patientId);
            var result = await _uow.Doctors.All.Where(i => i.Id == patient.DoctorUserId).ToListAsync();
            return _mapper.Map<List<UserDTO>>(result);
        }
    }
}
