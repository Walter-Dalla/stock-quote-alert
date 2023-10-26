using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using stock_quote_alert.Src.Configs;
using stock_quote_alert.Src.Dto;
using stock_quote_alert.Src.Helpers;
using stock_quote_alert.Src.Services;
using stock_quote_alert.Src.Services.Implementation;

namespace stock_quote_alert.Src.Workers
{

    //# Decidi utilizar o BackgroundService pois esse worker vai rodar em background em uma thread sepada do sistema,
    //# no caso atual o projeto é unico e exclusivo para esse worker mas se caso houvesse um outro sistema como uma API ou outros workers fica mais facil de coordenar.
    //# Além disso o BackgroundService é otimizado para rodar em background e implementa o CancellationToken de forma nativa facilitando uma possivel parada.

    internal class CronWorker : BackgroundService
    {
        private readonly ILogger<CronWorker> Logger;
        private readonly IEmailSenderService _emailSenderService;
        public CronWorker(ILogger<CronWorker> logger, IEmailSenderService emailSenderService)
        {
            Logger = logger;
            _emailSenderService = emailSenderService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var minThreshold = 10m;
            var maxThreshold = 90m;

            var stockName = "PETR4";

            while (!stoppingToken.IsCancellationRequested)
            {
                // simulando o retorno de uma Requisição e/ou de uma mensagem via WebSocket
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

                    Console.WriteLine(emailData.Body);
                    _emailSenderService.SendEmail(emailData);
                }

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
