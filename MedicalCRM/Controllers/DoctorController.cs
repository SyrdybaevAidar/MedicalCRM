using AutoMapper;
using MedicalCRM.Business.Models;
using MedicalCRM.Business.Services.Interfaces;
using MedicalCRM.Models.Patient;
using MedicalCRM.Models.UserModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MedicalCRM.Models;
using MedicalCRM.Models.Pagination;
using MedicalCRM.DataAccess.Enums;
using MedicalCRM.DataAccess.Static;

namespace MedicalCRM.Controllers {
    [Authorize(Roles = "Doctor")]
    public class DoctorController : BaseController {
        private readonly IDoctorService _doctorService;
        private readonly ICommonService _commonService;
        private readonly IConsultationService _consultationService;
        private readonly IPatientManager _patientService;
        private readonly IMapper _mapper;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        private readonly IChatService _chatService;
        public DoctorController(IDoctorService doctorService, IMapper mapper, ICommonService commonService, IConsultationService consultationService, IPatientManager patientManager, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment, IChatService chatService) {
            _mapper = mapper;
            _doctorService = doctorService;
            _commonService = commonService;
            _consultationService = consultationService;
            _patientService = patientManager;
            _hostingEnvironment = hostingEnvironment;
            _chatService = chatService;
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id) {
            var result = await _doctorService.GetDoctor(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Index() {
            try {
                var result = await _commonService.GetPatients(new PatientFilterDTO() { DoctorId = CurrentUserId });
                var consulations = await _consultationService.GetByDoctorId(CurrentUserId, 3);
                var patients = _mapper.Map<List<UserIndexViewModel>>(result.Users);
                var m = new DoctorMainPageViewModel() { Patients = patients, Consultations = _mapper.Map<List<ConsultationIndexModel>>(consulations) };

                return View(new DoctorMainPageViewModel() { Patients = patients, Consultations = _mapper.Map<List<ConsultationIndexModel>>(consulations) });
            } catch (Exception e) {
                return Ok(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Chats() {
            var dtos = await _chatService.GetChatByDoctorId(CurrentUserId);
            if (dtos != null && dtos.Count() > 0) {
                dtos = dtos.OrderByDescending(i => i.Messages.Count() > 0 ? i.Messages.First().SendDate : new DateTime()).ToList();
            }
            return View(dtos);
        }

        [HttpGet]
        public async Task<IActionResult> Patients(PatientFilterDTO filterDTO) {
            try {
                var filterResult = await _commonService.GetPatients(filterDTO);
                var result = new UserPaginationViewModel() { FilterResult = filterResult, PatientFilter = filterDTO};

                return View(result);
            } catch (Exception e) {
                return Ok(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreatePatient() {
            var bloodTypes = await _commonService.BloodTypes();
            ViewBag.Sex = new SelectList(EnumsExtensions.GetSexLookUpItem(), "Key", "Value");
            ViewBag.BloodTypes = new SelectList(bloodTypes, "Id", "Name");
            return View("Register", new PatientRegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatient(PatientRegisterViewModel model) {
            if (ModelState.IsValid) {
                var user = _mapper.Map<UserDTO>(model);
                user.Password = "Test123!";
                user.DoctorUserId = CurrentUserId;
                //user.BirthDate = user.BirthDate.ToUniversalTime();
                var result = await _patientService.RegisterAsync(user);

                if (result.Succeeded) {
                    var patient = await _patientService.GetByUserNameAsync(user.UserName);
                    patient.PassportId = model.PassportId;
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
            ViewBag.Sex = new SelectList(EnumsExtensions.GetSexLookUpItem(), "Key", "Value");
            ViewBag.BloodTypes = new SelectList(bloodTypes, "Id", "Name");
            return View("Update", result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePatient(PatientUpdateViewModel model) {
            if (ModelState.IsValid) {


                var patient = await _patientService.GetByUserNameAsync(model.UserName);
                patient.Patronimic = model.Patronimic;
                patient.Surname = model.Surname;
                patient.Name = model.Name;
                patient.BloodTypeId = model.BloodTypeId;
                patient.DoctorUserId = model.DoctorUserId;
                patient.Address = model.Address;
                patient.UserName = model.UserName;
                patient.BirthDate = model.BirthDate;
                patient.Email = model.Email;
                patient.Sex = model.Sex;
                patient.Id = model.Id;
                patient.PassportId = model.PassportId;
                await _patientService.UpdateUserAsync(patient);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> AddPhoto() {
            return View(new AddPhotoViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddPhoto(AddPhotoViewModel model) {
            return RedirectToAction("AddPhoto", model);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Login() {
            return View(new UserAuthorizationViewModel());
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserAuthorizationViewModel model) {

            if (ModelState.IsValid) {
                var user = _mapper.Map<UserDTO>(model);
                var result = await _patientService.LoginAsync(user, model.RememberMe);
                if (result == UserType.Admin) {
                    return RedirectToAction("Index", "Admin");
                }
                if (result == UserType.Doctor) {
                    return RedirectToAction("Index", "Doctor");
                }

            } else {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View();
                }
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View();
        }
    }
}
