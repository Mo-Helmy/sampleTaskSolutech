using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Task.Core.Interfaces;

namespace Task.Core.Extensions;

public static class ServicesExtensions
{
    public static void AutoRegisterServices(
        this IServiceCollection services, Assembly[] assemblies)
    {
        services.Scan(scan => scan.FromAssemblies(assemblies)
            .AddClasses(classes => classes.AssignableTo<IScopedService>())
            .AsImplementedInterfaces()
            .WithScopedLifetime()
            .AddClasses(classes => classes.AssignableTo<ITransientService>())
            .AsImplementedInterfaces()
            .WithTransientLifetime()
            .AddClasses(classes => classes.AssignableTo<ISingltonService>())
            .AsImplementedInterfaces()
            .WithSingletonLifetime());
    }

    public static void AddAutoMapperProfiles(
        this IServiceCollection services, Assembly[] assemblies)
        => services.AddAutoMapper(assemblies);
}