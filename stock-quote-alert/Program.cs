﻿
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using stock_quote_alert.Configs;
using stock_quote_alert.Services.Implementation;
using stock_quote_alert.Services.Interface;
using stock_quote_alert.Workers;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("AppSettings.json", optional: false);

//# Adicionado como singleton para poder injetar em qualquer dependencia futura do sistema
builder.Services.AddSingleton(builder.Configuration.GetSection("email").Get<EmailSettings>() ?? new EmailSettings());
builder.Services.AddSingleton(builder.Configuration.GetSection("smtp").Get<SmtpSettings>() ?? new SmtpSettings());

builder.Services.AddHostedService<CronWorker>();

//# Adicionei o IEmailSenderService como Singleton pois sua implementação pode ser unica na memoria,
// caso fosse um service de uma API ou que seu escopo mudasse a cada chamada e/ou podesse interferir com locks (como um repositorio) usaria o AddScoped
builder.Services.AddSingleton<IEmailSenderService, EmailSenderService>();

IHost host = builder.Build();

host.Run();
