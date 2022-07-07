using AutoMapper;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using MedicalCRM.Business.Models;
using MedicalCRM.Business.Services.Interfaces;
using MedicalCRM.DataAccess.Entities.UserEntities;
using MedicalCRM.DataAccess.Enums;
using MedicalCRM.Extensions;
using MedicalCRM.Models.ChatModels;
using MedicalCRM.Models.Patient;
using MedicalCRM.Models.UserModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace MedicalCRM.Controllers {

    public class PatientController : BaseController {
        private readonly IChatService _chatService;
        private readonly IConsultationService _consultationService;
        private readonly IPatientManager _patientManager;
        private readonly IPatientService _patientService;
        private readonly ICommonService _commonService;
        private readonly IReceptService _receptService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public PatientController(IMapper mapper, IChatService chatService, IConsultationService consultationService, IPatientManager patientManager, IPatientService patientService, ICommonService commonService, IReceptService receptService, UserManager<User> userManager) {

            _mapper = mapper;
            _chatService = chatService;
            _consultationService = consultationService;
            _patientManager = patientManager;
            _patientService = patientService;
            _commonService = commonService;
            _receptService = receptService;
            _userManager = userManager;
        }
        [Authorize(Roles = "Patient")]
        [HttpGet]
        public async Task<IActionResult> Index() {
            var result = await _commonService.GetDoctors(CurrentUserId);
            var doctors = _mapper.Map<List<UserIndexViewModel>>(result);
            var consulations = await _consultationService.GetByPatientId(CurrentUserId, 3);
            var chat = await _chatService.GetChatByPatientId(CurrentUserId);
            var message = chat?.FirstOrDefault()?.Messages?.FirstOrDefault();

            return View(new PatientMainPageIndexModel() { Doctors = doctors, Consultations = _mapper.Map<List<ConsultationIndexModel>>(consulations), LastMessage = message});
        }
        [Authorize(Roles = "Patient")]
        [HttpPost]
        public async Task<IActionResult> Private(int chatId) {
            var result = await _chatService.GetChatByPatientId(chatId);
            return View(_mapper.Map<ChatDetailsViewModel>(result));
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetPatientDetails(int patientId) {
            var dto = await _patientService.GetPatient(patientId);
            return View("Details", _mapper.Map<PatientDetailsViewModel>(dto));
        }
        [Authorize(Roles = "Patient, Doctor")]
        [HttpGet]
        public async Task<IActionResult> Details() {
            var dto = await _patientService.GetPatient(CurrentUserId);
            var result = _mapper.Map<PatientDetailsViewModel>(dto);
            return View(result);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Login() {
            if (User.Identity.IsAuthenticated) {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user.UserType == UserType.Doctor) {
                    return RedirectToAction("Index", "Doctor");
                }
                if (user.UserType == UserType.Admin) {
                    return RedirectToAction("Index", "Admin");
                }

                if (user.UserType == UserType.Patient) {
                    return RedirectToAction("Index", "Patient");
                }
            }
            return View(new PatientLoginViewModel());
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(PatientLoginViewModel model) {
            var result = await _patientManager.LoginAsync(model.Inn, model.RememberMe);
            if (result == UserType.Unauthorized) {
                ModelState.AddModelError(string.Empty, "Паицента с таким ИНН в базе не существует.");
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> SendRecept(int receptId) {

            try {
                var recept = await _receptService.GetById(receptId);
                var model = new ReceptFormViewModel();
                model.Recept = recept;
                model.User = _mapper.Map<UserDTO>(recept.Consultation.Patient);
                model.Doctor = _mapper.Map<UserDTO>(recept.Consultation.Doctor);
                var strings = await this.RenderViewToString("ReceptForm", model);
                var smtpClient = new System.Net.Mail.SmtpClient("smtp.mail.ru", 587);
                smtpClient.Credentials = new System.Net.NetworkCredential("medical_family_center@mail.ru", "wSopjHPpYtgAwBPLamMM");
                smtpClient.EnableSsl = true;
                var message = new System.Net.Mail.MailMessage("medical_family_center@mail.ru", model.User.Email, $"Рецепт от: {model.Doctor.GetFullName()}", "Доктор назначил ваш рецептуру, подробно с ней можно ознакомиться в документе ниже");
                message.Body = strings;
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                smtpClient.Send(message);
                return RedirectToAction("Details", "Consultation", new { consultationId = recept.ConsultationId });
            } catch (Exception e) {
                return BadRequest(e.InnerException + "   " + e.Message);
            }
        }
    }
}
