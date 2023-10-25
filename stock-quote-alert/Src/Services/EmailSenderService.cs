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
        private readonly EmailSettings Settings;
        public EmailSenderService(EmailSettings emailSettings)
        {
            Settings = emailSettings;
        }

        public void SendEmail(EmailDto emailData)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress(Settings.EmailAddressSender),
                Subject = emailData.Subject,
                Body = emailData.Body,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(Settings.EmailAddressRecipient);


            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(Settings.EmailAddressSender, Settings.Password),
                EnableSsl = true,
            };

            smtpClient.Send(mailMessage);
        }
    }
}
