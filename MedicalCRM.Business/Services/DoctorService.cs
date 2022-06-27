using AutoMapper;
using MedicalCRM.Business.Models;
using MedicalCRM.Business.Services.Interfaces;
using MedicalCRM.Business.UOWork;
using MedicalCRM.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Services {
    internal class DoctorService : BaseService, IDoctorService {
        public DoctorService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) {

        }
        public Task AddForm() {
            throw new NotImplementedException();
        }

        public async Task<DoctorDTO?> GetDoctor(int id) {
            var entity = await _uow.Doctors.GetDoctorWithNavigationAsync(id);
            var result = _mapper.Map<DoctorDTO>(entity);
            return result;
        }

        public async Task<List<UserDTO>> GetDoctors() {
            return _mapper.Map<List<UserDTO>>(await _uow.Doctors.GetAllAsync());
        }

        public async Task<List<BloodTypeDTO>> BloodTypes() {
            return _mapper.Map<List<BloodTypeDTO>>(await _uow.BloodTypes.GetAllAsync());
        }

        public async Task<List<Disease>> GetDiseasesAsync() {
            return _mapper.Map<List<Disease>>(await _uow.Diseases.GetAllAsync());
        }
    }
}
