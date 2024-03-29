﻿using GlobalTicket.CelanArch.Application.Contracts.Infrastructure;
using GlobalTicket.CelanArch.Application.Models.Mail;
using GlobalTicket.TicketManagement.Infrastructure.FileExport;
using GlobalTicket.TicketManagement.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalTicket.TicketManagement.Infrastructure;
public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services
        , IConfiguration config)
    {
        services.Configure<EmailSettings>(config.GetSection("EmailSettings"));

        services.AddTransient<IEmailService, EmailService>();
        services.AddTransient<ICsvExporter, CsvExporter>();

        return services;
    }
}
