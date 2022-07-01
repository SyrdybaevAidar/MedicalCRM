using AutoMapper;
using MedicalCRM.Business.Models;
using MedicalCRM.Business.Services.Interfaces;
using MedicalCRM.Models.Patient;
using Microsoft.AspNetCore.Authorization;
 using Microsoft.AspNetCore.Mvc;

namespace MedicalCRM.Controllers {
    public class ConsultationController : BaseController {
        private readonly IConsultationService _consultationService;
        private readonly ICommonService _commonService;
        private readonly IMapper _mapper;
        public ConsultationController(IConsultationService consultationService, ICommonService commonService,IMapper mapper) {
            _consultationService = consultationService;
            _commonService = commonService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Details(int consulationId) {
            var dto = await _consultationService.GetConsultationById(consulationId);
            var model = _mapper.Map<ConsultationViewModel>(dto);
            return View(model);
        }

        [Authorize(Roles ="Doctor")]
        [HttpGet]
        public async Task<IActionResult> Create(int patientId) {
            var model = new ConsultationViewModel();
            model.PatientId = patientId;
            model.DoctorId = CurrentUserId;
            return View(model);
        }

        [Authorize(Roles = "Doctor")]
        [HttpPost]
        public async Task<IActionResult> Create(ConsultationViewModel model) {
            var dto = _mapper.Map<ConsultationDTO>(model);
            await _consultationService.AddConsultation(dto);
            return RedirectToAction("DoctorConsultations");
        }

        [Authorize(Roles = "Doctor")]
        [HttpPost]
        public async Task<IActionResult> Update(ConsultationViewModel model) {
            var dto = _mapper.Map<ConsultationDTO>(model);
            await _consultationService.EditConsultation(dto);
            return RedirectToAction("DoctorConsultations");
        }

        [Authorize(Roles = "Doctor")]
        [HttpGet]
        public async Task<IActionResult> Update(int consulationId) {
            var dto = await _consultationService.GetConsultationById(consulationId);
            var model = _mapper.Map<ConsultationViewModel>(dto);
            return View(model);
        }
        [Authorize(Roles = "Patient")]
        [HttpGet]
        public async Task<IActionResult> PatientConsultations() {
            var dtos = await _consultationService.GetByPatientId(CurrentUserId);
            var models = _mapper.Map<List<ConsultationIndexModel>>(dtos);
            return View("Index", models);
        }
        [Authorize(Roles = "Doctor")]
        [HttpGet]
        public async Task<IActionResult> DoctorConsultations() {
            var dtos = await _consultationService.GetByDoctorId(CurrentUserId);
            var models = _mapper.Map<List<ConsultationIndexModel>>(dtos);
            return View("Index", models);
        }
    }
}
