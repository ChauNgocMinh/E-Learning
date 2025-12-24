using E_Learning.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Extensions;
public static class MigrationExtensions
{
    /// <summary>
    /// Quét hết các migration và áp dụng chúng vào database khi ứng dụng khởi động
    /// nếu có migration mới chưa được áp dụng thì sẽ tự động áp dụng
    /// </summary>
    /// <param name="app"></param>
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        db.Database.Migrate();
    }
}
