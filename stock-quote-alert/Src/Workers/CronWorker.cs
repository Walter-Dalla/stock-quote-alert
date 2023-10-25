using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using stock_quote_alert.Src.Configs;
using stock_quote_alert.Src.Dto;
using stock_quote_alert.Src.Services;

namespace stock_quote_alert.Src.Workers
{
    internal class CronWorker : BackgroundService
    {
        private readonly EmailSettings EmailSettings;
        private readonly SmtpSettings SmtpSettings;
        private readonly ILogger<CronWorker> Logger;
        public CronWorker(EmailSettings emailSettings, SmtpSettings smtpSettings, ILogger<CronWorker> logger)
        {
            EmailSettings = emailSettings;
            SmtpSettings = smtpSettings;
            Logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var minThreshold = 10m;
            var maxThreshold = 90m;

            var stockName = "PETR4";

            while (!stoppingToken.IsCancellationRequested)
            {
                var randomStockQuoteValue = new Random().Next(0, 100);
                var sendEmail = false;

                if (randomStockQuoteValue <= minThreshold)
                {
                    sendEmail = true;
                }
                else if(randomStockQuoteValue >= maxThreshold)
                {
                    sendEmail = true;
                }

                Logger.LogDebug("randomStockQuoteValue: " + randomStockQuoteValue);
                Console.WriteLine("randomStockQuoteValue: " + randomStockQuoteValue);
                if (sendEmail)
                {
                    var up = randomStockQuoteValue >= maxThreshold;
                    var threshold = up ? maxThreshold : minThreshold;
                    var emailData = EmailFormatter.FormatEmail(randomStockQuoteValue, up, threshold, stockName);

                    var emailSenderService = new EmailSenderService(EmailSettings, SmtpSettings);
                    Console.WriteLine(emailData.Body);
                    emailSenderService.SendEmail(emailData);
                }

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
