using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using Task.Application.StoreServices;
using Task.Application.StoreServices.Dto;

namespace Task.Application
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationsServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IStoreService, StoreService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Get Fluent Validators
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
