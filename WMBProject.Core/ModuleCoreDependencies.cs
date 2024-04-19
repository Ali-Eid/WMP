using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using WMBProject.Core.Behaviors;

namespace WMBProject.Core;

public static class ModuleCoreDependencies
{
    public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
    {
        //configuration MediatR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        //configuration AuttoMapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        // Get Validators
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        // 
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


        return services;
    }
}

