using AutoMapper;
using MedicalCRM.Business.Models;
using MedicalCRM.Business.Services.Interfaces;
using MedicalCRM.DataAccess.Static;
using MedicalCRM.Models.Admin;
using MedicalCRM.Models.Pagination;
using MedicalCRM.Models.Patient;
using MedicalCRM.Models.UserModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicalCRM.Controllers {
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller {
        private readonly IDoctorManager _doctorManager;
        private readonly ICommonService _commonService;
        private readonly IPatientManager _patientManager;
        private readonly IMapper _mapper;
        public AdminController(IDoctorManager doctorManager, IMapper mapper, ICommonService commonService, IPatientManager patientManager) {
            _doctorManager = doctorManager;
            _commonService = commonService;
            _mapper = mapper;
            _patientManager = patientManager;   
        }

        [HttpGet]
        public async Task<IActionResult> DoctorRegister() {
            ViewBag.Sex = new SelectList(EnumsExtensions.GetSexLookUpItem(), "Key", "Value");
            return View(new UserRegistrationViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> DoctorRegister(UserRegistrationViewModel model) {
            ViewBag.Sex = new SelectList(EnumsExtensions.GetSexLookUpItem(), "Key", "Value");
            var dto = _mapper.Map<UserDTO>(model);
            await _doctorManager.RegisterAsync(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DoctorUpdate(int doctorId) {
            var doctor = await _doctorManager.GetById(doctorId);
            var result = _mapper.Map<UserUpdateViewModel>(doctor);
            ViewBag.Sex = new SelectList(EnumsExtensions.GetSexLookUpItem(), "Key", "Value");
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> DoctorUpdate(UserUpdateViewModel model) {
            var patient = await _doctorManager.GetById(model.Id);
            patient.Patronimic = model.Patronimic;
            patient.Surname = model.Surname;
            patient.Name = model.Name;
            patient.UserName = model.UserName;
            patient.BirthDate = model.BirthDate;
            patient.Email = model.Email;
            patient.Sex = model.Sex;
            patient.Id = model.Id;
            await _doctorManager.Update(patient);
            ViewBag.Sex = new SelectList(EnumsExtensions.GetSexLookUpItem(), "Key", "Value");



            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> AddPatientByDoctor(int doctorId) {
            var bloodTypes = await _commonService.BloodTypes();
            ViewBag.Sex = new SelectList(EnumsExtensions.GetSexLookUpItem(), "Key", "Value");
            ViewBag.BloodTypes = new SelectList(bloodTypes, "Id", "Name");
            var model = new PatientRegisterViewModel();
            model.DoctorUserId = doctorId;
            return View("PatientRegister", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPatientByDoctor(PatientRegisterViewModel model) {
            if (ModelState.IsValid) {
                var user = _mapper.Map<UserDTO>(model);
                user.Password = "Test123!";
                //user.BirthDate = user.BirthDate.ToUniversalTime();
                var result = await _patientManager.RegisterAsync(user);

                if (result.Succeeded) {
                    var patient = await _patientManager.GetByUserNameAsync(user.UserName);
                    patient.PassportId = model.PassportId;
                    patient.Address = model.Address;
                    patient.BloodTypeId = model.BloodTypeId;
                    patient.DoctorUserId = model.DoctorUserId;
                    await _patientManager.UpdateUserAsync(patient);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Doctors(PatientFilterDTO patient) {
            var doctors = await _commonService.GetDoctors(patient);
            var result = new UserPaginationViewModel() { FilterResult = doctors, PatientFilter = patient};
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Patients(PatientFilterDTO filter) {
            var patients = await _commonService.GetPatients(filter);
            var result = new UserPaginationViewModel() { FilterResult = patients, PatientFilter = filter };
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Login() {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Index() {
            var result = new AdminPageViewModel();
            result.LastPatients = await _commonService.GetNewPatients();
            result.LastDoctors = await _commonService.GetNewDoctors();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> ChangeDoctorPassword(int doctorId) {
            var doctor = await _doctorManager.GetById(doctorId);
            if (doctor == null) {
                return BadRequest("Нет такого доктора");
            }
            return View(new ChangePassword() { DoctorId = doctorId, DoctorName = doctor.GetFullName() });
        }

        [HttpPost]
        public async Task<IActionResult> ChangeDoctorPassword(ChangePassword model) {
            await _doctorManager.ChangePassword(model.DoctorId, model.Password);
            return RedirectToAction("DoctorUpdate", new { doctorId = model.DoctorId });
        }

    }
}
