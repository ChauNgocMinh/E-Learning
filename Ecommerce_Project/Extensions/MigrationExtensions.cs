using Ecommerce_Project.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Project.Extensions;
public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        db.Database.Migrate();
    }
}
