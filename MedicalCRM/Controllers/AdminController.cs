using AutoMapper;
using MedicalCRM.Business.Models;
using MedicalCRM.Business.Services.Interfaces;
using MedicalCRM.Models.Admin;
using MedicalCRM.Models.Pagination;
using MedicalCRM.Models.UserModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCRM.Controllers {
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller {
        private readonly IDoctorManager _doctorManager;
        private readonly ICommonService _commonService;
        private readonly IMapper _mapper;
        public AdminController(IDoctorManager doctorManager, IMapper mapper, ICommonService commonService) {
            _doctorManager = doctorManager;
            _commonService = commonService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> DoctorRegister() {
            return View(new UserRegistrationViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> DoctorRegister(UserRegistrationViewModel model) {
            var dto = _mapper.Map<UserDTO>(model);
            await _doctorManager.RegisterAsync(dto);
            return View("Index");
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

        // GET: AdminController
        public async Task<ActionResult> Index() {
            var result = new AdminPageViewModel();
            result.LastPatients = await _commonService.GetNewPatients();
            result.LastDoctors = await _commonService.GetNewPatients();
            return View(result);
        }
    }
}
