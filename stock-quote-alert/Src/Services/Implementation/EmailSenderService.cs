using stock_quote_alert.Src.Configs;
using stock_quote_alert.Src.Dto;
using stock_quote_alert.Src.Services.Interface;
using System.Net;
using System.Net.Mail;

namespace stock_quote_alert.Src.Services.Implementation
{
    public class EmailSenderService : IEmailSenderService
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
