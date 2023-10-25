using stock_quote_alert.Src.Dto;

namespace stock_quote_alert.Src.Services
{
    public class EmailFormatter
    {

        public static EmailDto FormatEmail(decimal stockQuoteValue, bool thresholdUp, decimal threshold, string stockName)
        {

            var action = "";
            var headerAction = "";

            if (thresholdUp)
            {
                headerAction = "alta";
                action = "compra";
            }
            else
            {
                headerAction = "baixa";
                action = "compra";
            }

            var subject = $"Alerta de Cotação {headerAction}";

            var emailHtml = $@"<!DOCTYPE html>
                <html>
                <head>
                    <title>{subject}</title>
                </head>
                <body>
                    <p>A cotação da ação {stockName} atingiu o valor {stockQuoteValue}.</p>
                    <p>Preço atual: {stockQuoteValue}</p>
                    <p>Preço de referência para {action}: {threshold}</p>
                </body>
                </html>
            ";


            return new EmailDto()
            {
                Subject = subject,
                Body = emailHtml
            }; ;

        }

    }
}
