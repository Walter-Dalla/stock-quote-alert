using stock_quote_alert.Src.Configs;
using stock_quote_alert.Src.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace stock_quote_alert.Src.Services
{
    public class EmailSenderService
    {
        private readonly EmailSettings EmailSettings;
        private readonly SmtpSettings SmtpSettings;
        public EmailSenderService(EmailSettings emailSettings, SmtpSettings smtpSettings)
        {
            EmailSettings = emailSettings;
            SmtpSettings = smtpSettings;
        }

        public void SendEmail(EmailDto emailData)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress(EmailSettings.EmailAddressSender),
                Subject = emailData.Subject,
                Body = emailData.Body,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(EmailSettings.EmailAddressRecipient);


            var smtpClient = new SmtpClient(SmtpSettings.Server)
            {
                Port = SmtpSettings.Port,
                Credentials = new NetworkCredential(EmailSettings.EmailAddressSender, EmailSettings.Password),
                EnableSsl = SmtpSettings.EnableSsl,
            };

            smtpClient.Send(mailMessage);
        }
    }
}
