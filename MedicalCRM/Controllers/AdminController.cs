using AutoMapper;
using MedicalCRM.Business.Models;
using MedicalCRM.Business.Services.Interfaces;
using MedicalCRM.Models.UserModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCRM.Controllers {

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
        public async Task<IActionResult> Doctors() {
            var doctors = await _commonService.GetDoctors();
            return View("Users", doctors);
        }

        [HttpGet]
        public async Task<IActionResult> Patients(PatientFilterDTO filter) {
            var patients = await _commonService.GetPatients(filter);
            return View("Users", patients);
        }

        [HttpGet]
        public async Task<IActionResult> Login() {
            return View();
        }

        // GET: AdminController
        public ActionResult Index() {
            return View();
        }
    }
}
