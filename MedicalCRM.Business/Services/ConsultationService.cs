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
    public class ConsultationService: IConsultationService {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public ConsultationService(IUnitOfWork uow, IMapper mapper) { 
            _uow = uow;
            _mapper = mapper;
        }

        public async Task AddConsultation(ConsultationDTO dto) {
            var entity = _mapper.Map<Consultation>(dto);
            var result = await _uow.Consultations.InsertAsync(entity);
            await _uow.SaveChangesAsync();

            var diseases = new List<ConsultationDisease>();
            foreach (var i in dto.ChronicalDiseasesIds) {
                diseases.Add(new ConsultationDisease { ConsultationId = result.Id, DiseaseId = i });
            }

            await _uow.ConsultationDiseases.InsertAsync(diseases);
            await _uow.SaveChangesAsync();
        }

        public async Task EditConsultation(ConsultationDTO consultation) {
            var entity = _mapper.Map<Consultation>(consultation);
            _uow.Consultations.Update(entity);
            var diseases = new List<ConsultationDisease>();
            foreach (var i in consultation.ChronicalDiseasesIds) {
                diseases.Add(new ConsultationDisease { ConsultationId = entity.Id, DiseaseId = i });
            }
            var ids = await _uow.ConsultationDiseases.All.AsNoTracking().Where(i => i.ConsultationId == consultation.Id).Select(i => i.Id).ToListAsync();
            await _uow.ConsultationDiseases.DeleteByIds(ids);
            await _uow.SaveChangesAsync();
            await _uow.ConsultationDiseases.InsertAsync(diseases);
            await _uow.SaveChangesAsync();
        }

        public async Task<ConsultationDTO?> GetConsultationById(int Id) {
            var entity = await _uow.Consultations.All
                .Include(i => i.ChronicalDiseases)!.ThenInclude(i => i.Disease)
                .Include(i => i.Doctor)
                .Include(i => i.Patient)
                .Where(i => i.Id == Id)
                .FirstOrDefaultAsync();
            return _mapper.Map<ConsultationDTO>(entity);
        }
        public async Task<List<ConsultationDTO>> GetByDoctorId(int doctorId, int count = 0) {
            var entities = _uow.Consultations.All
                .Include(i => i.ChronicalDiseases!).ThenInclude(i => i.Disease)
                .Include(i => i.Doctor)
                .Include(i => i.Patient)
                .Where(i => i.DoctorId == doctorId);
            if (count > 0) {
                entities = entities.Take(count);
            }

            var result = await entities.OrderByDescending(i => i.Date)
                .ToListAsync();
            return _mapper.Map<List<ConsultationDTO>>(result);
        }

        public async Task<List<ConsultationDTO>> GetByPatientId(int patientId, int count = 0) {
            var entities = _uow.Consultations.All
                .Include(i => i.ChronicalDiseases!).ThenInclude(i => i.Disease)
                .Include(i => i.Doctor)
                .Include(i => i.Patient)
                .Where(i => i.PatientId == patientId);
            if (count > 0) {
                entities = entities.Take(count);
            }

            var result = await entities.OrderByDescending(i => i.Date)
                .ToListAsync();
            return _mapper.Map<List<ConsultationDTO>>(result);
        }

    }
}
