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
    public interface IEmailSenderService
    {
        public void SendEmail(EmailDto emailData);
    }
}
