using E_Learning.Cqrs.Handlers.SubmissionQueryHandlers;
using E_Learning.Infrastructure.Persistence;
using E_Learning.Mappings;
using E_Learning.Repositories.Imp;
using E_Learning.Repositories.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(
                typeof(GetMySubmissionsQueryHandler).Assembly
            )
        );

        services.AddScoped(typeof(ICommonRepository<>), typeof(CommonRepository<>));

        return services;
    }

    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddControllersWithViews();
        return services;
    }

    public static IServiceCollection AddAppDbContext(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
        return services;
    }
}

