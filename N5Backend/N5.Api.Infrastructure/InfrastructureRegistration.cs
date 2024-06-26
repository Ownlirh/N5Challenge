using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using N5.Api.Application.Contracts;
using N5.Api.Application.Services;
using N5.Api.Infrastructure.Context;
using N5.Api.Infrastructure.Repositories;
using N5.Api.Infrastructure.Services;

namespace N5.Api.Infrastructure;

public static class InfrastructureRegistration
{
    public static IServiceCollection AddInfrastructureServiceRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        var n5ConnectionString = configuration.GetConnectionString("n5ConnString");

        if (string.IsNullOrWhiteSpace(n5ConnectionString))
        {
            throw new KeyNotFoundException("Connection string not found: n5ConnString");
        }

        services.AddDbContext<N5Context>((options) => options.UseSqlServer(n5ConnectionString));

        services.AddTransient<IPermissionTypeRepository, PermissionTypeRepository>();
        services.AddTransient<IPermissionsRepository, PermissionRepository>();

        services.AddTransient<IPermissionsElasticSearchService, PermissionElasticSearchService>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
