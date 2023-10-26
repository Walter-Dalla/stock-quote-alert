using stock_quote_alert.Dto;

namespace stock_quote_alert.Services.Interface
{
    public interface IEmailSenderService
    {
        public void SendEmail(EmailDto emailData);
    }
}
