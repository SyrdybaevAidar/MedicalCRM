using AutoMapper;
using MedicalCRM.Business.UOWork;
using MedicalCRM.DataAccess.Entities;
using MedicalCRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalCRM.Controllers {
    public class ReceptController: BaseController 
    {
        private IMapper _mapper;
        private IUnitOfWork _uow;
        public ReceptController(IMapper mapper, IUnitOfWork unitOfWork) {
            _mapper = mapper;
            _uow = unitOfWork;
        }

        public async Task<IActionResult> Create(int consultationId) {
            var recept = new Recept() { ConsultationId = consultationId};
            await _uow.Recepts.InsertAsync(recept);
            await _uow.SaveChangesAsync();
            return RedirectToAction("Index", "Doctor");
        }

        public async Task<IActionResult> Details(int receptId) {
            var recept = await _uow.Recepts.All.Where(i => i.Id == receptId).
                Include(i => i.Medicaments).ThenInclude(i => i.Medicament).
                Include(i => i.Consultation).ThenInclude(i => i.Patient).
                Include(i => i.Consultation).ThenInclude(i => i.Doctor)
                .FirstOrDefaultAsync();
            return View(recept);
        }

        public async Task<IActionResult> AddMedicament(MedicamentCreateViewModel model) {
            var medicament = new ReceptByMedicament() { ReceptId = model.Id, MedicamentId = model.MedicamentId, Count = model.Count };
            await _uow.ReceptByMedicaments.InsertAsync(medicament);
            await _uow.SaveChangesAsync();
            return RedirectToAction("Details", model.Id);
        }
    }
}
