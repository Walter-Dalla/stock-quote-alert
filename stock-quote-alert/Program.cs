
using Microsoft.Extensions.Configuration;
using stock_quote_alert.Src.Configs;
using stock_quote_alert.Src.Dto;
using stock_quote_alert.Src.Services;

var builder = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("AppSettings.json", optional: false);
IConfiguration config = builder.Build();

var emailSettings = config.GetSection("email").Get<EmailSettings>();
var smtpSettings = config.GetSection("smtp").Get<SmtpSettings>();


var emailSenderService = new EmailSenderService(emailSettings, smtpSettings);
emailSenderService.SendEmail(new EmailDto()
{
    Subject = "Stock alert!",
    Body = "<h1> Stock </h1>"
});