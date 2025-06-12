using MediatR;
using Microsoft.EntityFrameworkCore;
using Ecommerce_Project.Infrastructure.Persistence;
using Ecommerce_Project.Mappings;

namespace Ecommerce_Project.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
        //services.AddScoped<IUserRepository, UserRepository>();
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

    public static IServiceCollection AddMappingProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapperProfile));
        return services;
    }
}

