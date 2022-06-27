using AutoMapper;
using MedicalCRM.Business.Models;
using MedicalCRM.Business.Services.Interfaces;
using MedicalCRM.DataAccess.Entities.UserEntities;
using MedicalCRM.Models.Patient;
using MedicalCRM.Models.UserModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicalCRM.Controllers {
    [Authorize(Roles = "Doctor")]
    public class DoctorController : BaseController {
        private readonly IDoctorService _doctorService;
        private readonly ICommonService _commonService;
        private readonly IConsultationService _consultationService;
        private readonly IPatientManager _patientService;
        private readonly IMapper _mapper;
        public DoctorController(IDoctorService doctorService, IMapper mapper, ICommonService commonService, IConsultationService consultationService, IPatientManager patientManager) {
            _mapper = mapper;
            _doctorService = doctorService;
            _commonService = commonService;
            _consultationService = consultationService;
            _patientService = patientManager;
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id) {
            var result = await _doctorService.GetDoctor(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Index() {
            
            var result = await _commonService.GetPatients(CurrentUserId);
            var consulations = await _consultationService.GetByDoctorId(CurrentUserId, 3);
            var patients = _mapper.Map<List<UserIndexViewModel>>(result);
            return View(new DoctorMainPageViewModel() { Patients = patients , Consultations = _mapper.Map<List<ConsultationIndexModel>>(consulations)});
        }

        [HttpGet]
        public async Task<IActionResult> CreatePatient() {
            var bloodTypes = await _commonService.BloodTypes();
            ViewBag.BloodTypes = new SelectList(bloodTypes, "Id", "Name");
            return View("Register", new PatientRegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatient(PatientRegisterViewModel model) {
            if (ModelState.IsValid) {
                var user = _mapper.Map<UserDTO>(model);
                user.Password = "Test123!";
                user.DoctorUserId = CurrentUserId;
                var result = await _patientService.RegisterAsync(user);

                if (result.Succeeded) {
                    var patient = await _patientService.GetByUserNameAsync(user.UserName);
                    patient.Address = model.Address;
                    patient.BloodTypeId = model.BloodTypeId;
                    patient.DoctorUserId = CurrentUserId;
                    await _patientService.UpdateUserAsync(patient);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePatient(int patientId) {
            var patient = await _patientService.GetById(patientId);
            var result = _mapper.Map<PatientUpdateViewModel>(patient);
            var bloodTypes = await _commonService.BloodTypes();
            ViewBag.BloodTypes = new SelectList(bloodTypes, "Id", "Name");
            return View("Update", result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePatient(PatientUpdateViewModel model) {
            if (ModelState.IsValid) {

                var entity = _mapper.Map<PatientUser>(model);
                entity.BloodTypeId = model.BloodTypeId;
                entity.DoctorUserId = model.DoctorUserId;
                await _patientService.UpdateUserAsync(entity);
            }
            return RedirectToAction("Index");
        }
    }
}
