using GemBox.Document;
using MedicalCRM.Models;
using MedicalCRM.Models.ChatModels;
using Microsoft.AspNetCore.Mvc;
using MedicalCRM.Extensions;
using System.Diagnostics;

namespace MedicalCRM.Controllers {
    public class HomeController : BaseController {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public async Task<IActionResult> Index() {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            var viewHtml = await this.RenderViewToString("Index", new object());
            var htmlLoadOptions = new HtmlLoadOptions();
            var stream = new MemoryStream();
            using (var htmlStream = new MemoryStream(htmlLoadOptions.Encoding.GetBytes(viewHtml))) {
                
                var document = DocumentModel.Load(htmlStream, htmlLoadOptions);
                // Save output PDF file.
                document.Save(stream, SaveOptions.PdfDefault);
            }

            var smtpClient = new System.Net.Mail.SmtpClient("smtp.mail.ru", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential("medical_center_crm@mail.ru", "3V0mYsZcVtl71OCzrhCj");
            smtpClient.EnableSsl = true;
            var message = new System.Net.Mail.MailMessage("medical_center_crm@mail.ru", "aidar_1997_kg@mail.ru", "Тема", "Сообщение");
            message.Attachments.Add(new System.Net.Mail.Attachment(stream, "recept.pdf"));
            smtpClient.Send(message);
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}