using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using stock_quote_alert.Configs;
using stock_quote_alert.Helpers;
using stock_quote_alert.Services.Interface;

namespace stock_quote_alert.Workers
{

    //# Decidi utilizar o BackgroundService pois esse worker vai rodar em background em uma thread sepada do sistema,
    //# no caso atual o projeto é unico e exclusivo para esse worker mas se caso houvesse um outro sistema como uma API ou outros workers fica mais facil de coordenar.
    //# Além disso o BackgroundService é otimizado para rodar em background e implementa o CancellationToken de forma nativa facilitando uma possivel parada.

    internal class CronWorker : BackgroundService
    {
        private readonly ILogger<CronWorker> _logger;
        private readonly IEmailSenderService _emailSenderService;
        private readonly ThresholdSettings _thresholdSettings;
        public CronWorker(ILogger<CronWorker> logger, IEmailSenderService emailSenderService, ThresholdSettings thresholdSettings)
        {
            _logger = logger;
            _emailSenderService = emailSenderService;
            _thresholdSettings = thresholdSettings;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var minThreshold = _thresholdSettings.MinThreshold;
            var maxThreshold = _thresholdSettings.MaxThreshold;

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
                else if (randomStockQuoteValue >= maxThreshold)
                {
                    sendEmail = true;
                }

                _logger.LogDebug("randomStockQuoteValue: " + randomStockQuoteValue);
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
