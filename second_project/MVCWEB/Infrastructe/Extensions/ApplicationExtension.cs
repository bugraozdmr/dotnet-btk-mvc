using Entities.Models;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Identity;
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

    public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
    {
        const string adminUser = "Admin";
        const string adminPassword = "Admin+123456";
        
        // User Manager
        UserManager<User> userManager = app
            .ApplicationServices
            .CreateScope()
            .ServiceProvider
            .GetService<UserManager<User>>();
        
        // Role Manager -- admine tüm rolleri vermek istiyor
        RoleManager<IdentityRole> roleManager = app
            .ApplicationServices
            .CreateAsyncScope()
            .ServiceProvider
            .GetRequiredService<RoleManager<IdentityRole>>();

        User user = await userManager.FindByNameAsync(adminUser);
        if (user is null)
        {
            user = new User()
            {
                FirstName = "Grant",
                LastName = "Wick",
                Email = "bugra.ozdemir@gmail.com",
                PhoneNumber = "5061024511",
                UserName = adminUser
            };

            var result = await userManager.CreateAsync(user, adminPassword);
            if (!result.Succeeded)
                throw new Exception("Admin could not created.");

            // tüm rolleri admin aldı
            var roleResult = await userManager.AddToRolesAsync(user,
                roleManager
                    .Roles
                    .Select(r => r.Name)
                    .ToList());

            if (!roleResult.Succeeded)
                throw new Exception("System have problems with role defination for admin.");
        }
    } 
}