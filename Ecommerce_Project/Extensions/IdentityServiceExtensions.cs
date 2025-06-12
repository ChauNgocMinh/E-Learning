using Ecommerce_Project.Infrastructure.Persistence;
using Ecommerce_Project.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce_Project.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            return services;
        }
    }

}
