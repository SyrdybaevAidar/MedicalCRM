using MedicalCRM.Business.Models.Configuration;
using MedicalCRM.Business.Models.Email;
using MedicalCRM.Business.Services.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Services {
    public class MailService: IMailService {
        private OrganizationEmailConfiguration _emailConfig;
        public MailService(IOptions<OrganizationEmailConfiguration> emailConfig) {
            _emailConfig = emailConfig.Value;
        }
        public async Task SendMessage(EmailMessage model) {
            var smtpClient = new System.Net.Mail.SmtpClient("smtp.mail.ru", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential(_emailConfig.Email, _emailConfig.Password);
            smtpClient.EnableSsl = true;
            var message = new System.Net.Mail.MailMessage(_emailConfig.Email, model.Receiver, model.Theme, model.Text);
            message.Attachments.Add(new System.Net.Mail.Attachment(model.Attachment, "recept.pdf"));
            smtpClient.Send(message);
        }
    }
}
