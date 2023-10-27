﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GlobalTicket.CelanArch.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}
