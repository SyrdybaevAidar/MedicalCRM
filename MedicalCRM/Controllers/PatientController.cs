using AutoMapper;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using MedicalCRM.Business.Models;
using MedicalCRM.Business.Services.Interfaces;
using MedicalCRM.Extensions;
using MedicalCRM.Models.ChatModels;
using MedicalCRM.Models.Patient;
using MedicalCRM.Models.UserModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                var bytes = GetPdf(".headline{font-size:200%}", strings);
                var stream = new MemoryStream(bytes);
                var smtpClient = new System.Net.Mail.SmtpClient("smtp.mail.ru", 587);
                smtpClient.Credentials = new System.Net.NetworkCredential("medical_center_crm@mail.ru", "3V0mYsZcVtl71OCzrhCj");
                smtpClient.EnableSsl = true;
                var message = new System.Net.Mail.MailMessage("medical_center_crm@mail.ru", model.User.Email, $"Рецепт от: {model.Doctor.GetFullName()}", "Доктор назначил ваш рецептуру, подробно с ней можно ознакомиться в документе ниже");
                message.Attachments.Add(new System.Net.Mail.Attachment(stream, "recept.pdf"));
                smtpClient.Send(message);
                return RedirectToAction("Details", "Consultation", new { consultationId = recept.ConsultationId });
            } catch (Exception e) {
                return BadRequest(e.InnerException + "   " + e.Message);
            }
        }

        public byte[] GetPdf(string cssText, string html) {
            using (var memoryStream = new MemoryStream()) {
                var document = new Document(PageSize.A4, 50, 50, 60, 60);
                var writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                using (var cssMemoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(cssText))) {
                    using (var htmlMemoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(html))) {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, htmlMemoryStream, cssMemoryStream);
                    }
                }

                document.Close();

                return memoryStream.ToArray();
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
