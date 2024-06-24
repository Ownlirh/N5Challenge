using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using N5.Api.Application.Validators;
using System.Reflection;

namespace N5.Api.Application;

public static class ApplicationRegistration
{
    public static IServiceCollection AddApplicationServiceRegistration(this IServiceCollection services)
    {
        services.AddMediatR((cfg) => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CustomFluentValidatorBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // Services

        return services;

    }
}