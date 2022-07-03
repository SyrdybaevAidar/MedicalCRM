using AutoMapper;
using GemBox.Document;
using MedicalCRM.Business.Models;
using MedicalCRM.Business.Services.Interfaces;
using MedicalCRM.Extensions;
using MedicalCRM.Models.ChatModels;
using MedicalCRM.Models.Patient;
using MedicalCRM.Models.UserModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PdfSharp.Pdf;
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

        public PatientController(IMapper mapper, IChatService chatService, IConsultationService consultationService, IPatientManager patientManager, IPatientService patientService, ICommonService commonService, IReceptService receptService) {

            _mapper = mapper;
            _chatService = chatService;
            _consultationService = consultationService;
            _patientManager = patientManager;
            _patientService = patientService;
            _commonService = commonService;
            _receptService = receptService;
        }
        [Authorize(Roles = "Patient")]
        [HttpGet]
        public async Task<IActionResult> Index() {
            var result = await _commonService.GetDoctors(CurrentUserId);
            var doctors = _mapper.Map<List<UserIndexViewModel>>(result);
            var consulations = await _consultationService.GetByDoctorId(CurrentUserId, 3);
            return View(new PatientMainPageIndexModel() { Doctors = doctors, Consultations = _mapper.Map<List<ConsultationIndexModel>>(consulations) });
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
            return View(new PatientLoginViewModel());
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(PatientLoginViewModel model) {
            await _patientManager.LoginAsync(model.Inn, model.RememberMe);
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
                var stream = new MemoryStream();
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(strings, PdfSharp.PageSize.A4);
                pdf.Save(stream);
                var stream2 = new MemoryStream(stream.ToArray());
                var smtpClient = new System.Net.Mail.SmtpClient("smtp.mail.ru", 587);
                smtpClient.Credentials = new System.Net.NetworkCredential("medical_center_crm@mail.ru", "3V0mYsZcVtl71OCzrhCj");
                smtpClient.EnableSsl = true;
                var message = new System.Net.Mail.MailMessage("medical_center_crm@mail.ru", model.User.Email, $"Рецепт от: {model.Doctor.GetFullName()}", "Доктор назначил ваш рецептуру, подробно с ней можно ознакомиться в документе ниже");
                message.Attachments.Add(new System.Net.Mail.Attachment(stream2, "recept.pdf"));
                smtpClient.Send(message);
                return RedirectToAction("Details", "Consultation", new { consultationId = recept.ConsultationId });
            } catch (Exception e) { 
            
            }
        }

        public async Task<IActionResult> ReceptForm() {
            return View();
        }

        public string CssText() {
            return @"        
        .header{
            display: flex;
            justify-content: space-between;
        }

        .header-item1{
            max-width: 200px;
        }

        .header-item2{
            max-width: 200px;
        }";
        }
    }
}
