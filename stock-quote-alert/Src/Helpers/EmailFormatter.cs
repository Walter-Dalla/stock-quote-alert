using stock_quote_alert.Dto;

namespace stock_quote_alert.Helpers
{
    //# Como essa classe existe somente para liberar um Util ou Helper estatico ela não precisa ser salva no escopo "builder.Services"
    //# E não se caracteriza como um service e sim um utilitario por isso está separado na pasta de Helpers
    public class EmailFormatter
    {

        public static EmailDto FormatEmail(decimal stockQuoteValue, bool thresholdUp, decimal threshold, string stockName)
        {
            string headerAction;
            string action;

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
            };
        }
    }
}
