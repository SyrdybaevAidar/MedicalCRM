using AutoMapper;
using GemBox.Document;
using MedicalCRM.Business.Services.Interfaces;
using MedicalCRM.Extensions;
using MedicalCRM.Models.ChatModels;
using MedicalCRM.Models.Patient;
using MedicalCRM.Models.UserModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalCRM.Controllers {

    public class PatientController : BaseController {
        private readonly IChatService _chatService;
        private readonly IConsultationService _consultationService;
        private readonly IPatientManager _patientManager;
        private readonly IPatientService _patientService;
        private readonly ICommonService _commonService;
        private readonly IMapper _mapper;

        public PatientController(IMapper mapper, IChatService chatService, IConsultationService consultationService, IPatientManager patientManager, IPatientService patientService, ICommonService commonService) {
            
            _mapper = mapper;
            _chatService = chatService;
            _consultationService = consultationService;
            _patientManager = patientManager;
            _patientService = patientService;
            _commonService = commonService;
        }
        [Authorize(Roles = "Patient")]
        [HttpGet]
        public async Task<IActionResult> Index() {
            var result = await _commonService.GetDoctors(CurrentUserId);
            var doctors = _mapper.Map<List<UserIndexViewModel>>(result);
            var consulations = await _consultationService.GetByDoctorId(CurrentUserId, 3);
            return View(new PatientMainPageIndexModel() { Doctors = doctors , Consultations = _mapper.Map<List<ConsultationIndexModel>>(consulations) });
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
        [Authorize(Roles = "Patient")]
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
        public async Task<IActionResult> SendRecept(int PatientId) {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            var user = await _patientManager.GetById(PatientId);
            var htmlLoadOptions = new HtmlLoadOptions();
            var stream = new MemoryStream();
            using (var htmlStream = new MemoryStream(htmlLoadOptions.Encoding.GetBytes("<h1>Рецепт</h1>"))) {

                var document = DocumentModel.Load(htmlStream, htmlLoadOptions);
                document.Save(stream, SaveOptions.PdfDefault);
            }

            var smtpClient = new System.Net.Mail.SmtpClient("smtp.mail.ru", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential("medical_center_crm@mail.ru", "3V0mYsZcVtl71OCzrhCj");
            smtpClient.EnableSsl = true;
            var message = new System.Net.Mail.MailMessage("medical_center_crm@mail.ru", user.Email, "Тема", "Сообщение");
            message.Attachments.Add(new System.Net.Mail.Attachment(stream, "recept.pdf"));
            smtpClient.Send(message);
            return RedirectToAction("Index","Doctor", PatientId);
        }
    }
}
