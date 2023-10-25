
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using stock_quote_alert.Src.Configs;
using stock_quote_alert.Src.Workers;

{
   /* var builder = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("AppSettings.json", optional: false);
    IConfiguration config = builder.Build();

    var emailSettings = config.GetSection("email").Get<EmailSettings>();
    var smtpSettings = config.GetSection("smtp").Get<SmtpSettings>();


    var cronWorker = new CronWorker(emailSettings, smtpSettings);
   */
}




HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("AppSettings.json", optional: false);

builder.Services.AddSingleton<EmailSettings>(builder.Configuration.GetSection("email").Get<EmailSettings>());
builder.Services.AddSingleton<SmtpSettings>(builder.Configuration.GetSection("smtp").Get<SmtpSettings>());

builder.Services.AddHostedService<CronWorker>();

IHost host = builder.Build();

host.Run();
