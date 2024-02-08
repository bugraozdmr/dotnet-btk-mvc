using Marvin.Cache.Headers;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace MVCWEB.Infrastructe.Extensions;

// classic olmayan diğer metodlar buraya yazılacak
public static class ApplicationExtension
{
    // Otomatik migrationı database ile eşler -- çalışırsa eğer ÇALIŞMIYOR
    public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
    {
        RepositoryContext context = app
            .ApplicationServices
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<RepositoryContext>();

        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }
    }

    // dolar gelmesini engelledi ama sen git iyice izle metinler için çalış -- orda globalleştir
    public static void ConfigureLocalization(this IApplicationBuilder app)
    {
        app.UseRequestLocalization(options =>
        {
            options.AddSupportedCultures("tr-TR")
                .AddSupportedCultures("tr-TR")
                .SetDefaultCulture("tr-TR");
        });
    }
}