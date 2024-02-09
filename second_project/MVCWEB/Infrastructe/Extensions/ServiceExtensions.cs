using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCWEB.Models;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Concrats;

namespace MVCWEB.Infrastructe.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureDbContext(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("sqlConnection");

        services.AddDbContextPool<RepositoryContext>(opt =>
        {
            opt.UseMySql(connectionString, new MySqlServerVersion(new Version(10, 4, 28)));
            // geliştirmede bu olabilir
            opt.EnableSensitiveDataLogging(true);
        });
    }

    public static void ConfigureIdentity(this IServiceCollection services)
    {
        services.AddIdentity<User, IdentityRole>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.User.RequireUniqueEmail = true;
            options.Password.RequiredLength = 6;
            options.Password.RequireDigit = true;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = false;
        })
        .AddEntityFrameworkStores<RepositoryContext>()
        .AddDefaultTokenProviders();
    }
    
    public static void ConfigureSession(this IServiceCollection services)
    {
        // oturum yönetimi
        services.AddDistributedMemoryCache();
        services.AddSession(options =>
        {
            options.Cookie.Name = "StoreApp.Session";
            options.IdleTimeout = TimeSpan.FromMinutes(10);
        });
        
        services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
        
        // gelen elemanı al diyor -- sessiondan
        services.AddScoped<Cart>(c => SessionCart.GetCart(c));

    }

    public static void ConfigureRepositoryRegistration(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryManager, RepositoryManager>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
    }

    public static void ConfigureServiceRegistration(this IServiceCollection services)
    {
        services.AddScoped<IServiceManager, ServiceManager>();
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<IProductService, ProductManager>();
        services.AddScoped<IOrderService, OrderManager>();
    }

    public static void ConfigureRouting(this IServiceCollection services)
    {
        // artık urlde büyük harf almıyor otomatik küçültüyor -- artık sona / geliyor true olursa
        services.AddRouting(options =>
        {
            options.LowercaseUrls = true;
            options.AppendTrailingSlash = false;
        });
    }
}