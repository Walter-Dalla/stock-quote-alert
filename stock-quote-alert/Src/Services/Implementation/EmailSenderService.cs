using stock_quote_alert.Configs;
using stock_quote_alert.Dto;
using stock_quote_alert.Services.Interface;
using System.Net;
using System.Net.Mail;

namespace stock_quote_alert.Services.Implementation
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly EmailSettings _emailSettings;
        private readonly SmtpSettings _smtpSettings;
        public EmailSenderService(EmailSettings emailSettings, SmtpSettings smtpSettings)
        {
            _emailSettings = emailSettings;
            _smtpSettings = smtpSettings;
        }

        public void SendEmail(EmailDto emailData)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress(_emailSettings.EmailAddressSender),
                Subject = emailData.Subject,
                Body = emailData.Body,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(_emailSettings.EmailAddressRecipient);


            var smtpClient = new SmtpClient(_smtpSettings.Server)
            {
                Port = _smtpSettings.Port,
                Credentials = new NetworkCredential(_emailSettings.EmailAddressSender, _emailSettings.Password),
                EnableSsl = _smtpSettings.EnableSsl,
            };

            smtpClient.Send(mailMessage);
        }
    }
}
