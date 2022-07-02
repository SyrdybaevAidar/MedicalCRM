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
    public class ReceptService: IReceptService {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public ReceptService(IUnitOfWork uow, IMapper mapper) {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task Add(int consultationId) {
            var entity = new Recept() { ConsultationId = consultationId };
            await _uow.Recepts.InsertAsync(entity);
            await _uow.SaveChangesAsync();
        }

        public async Task AddMedicament(MedicamentDTO dto) {
            var entity = _mapper.Map<ReceptByMedicament>(dto);
            await _uow.ReceptByMedicaments.InsertAsync(entity);
        }

        public async Task DeleteMedicament(int id) {
            await _uow.ReceptByMedicaments.DeleteByIdAsync(id);
            await _uow.SaveChangesAsync();
        }

        public async Task<Recept> GetById(int id) {
            return await _uow.Recepts.All.Where(i => i.Id == id)
                .Include(i => i.Consultation).ThenInclude(i => i.Doctor)
                .Include(i => i.Consultation).ThenInclude(i => i.Patient)
                .Include(i => i.Medicaments)
                .FirstOrDefaultAsync();
        }
    }
}
