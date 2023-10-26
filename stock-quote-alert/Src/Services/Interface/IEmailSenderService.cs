using stock_quote_alert.Src.Dto;

namespace stock_quote_alert.Src.Services.Interface
{
    public interface IEmailSenderService
    {
        public void SendEmail(EmailDto emailData);
    }
}
