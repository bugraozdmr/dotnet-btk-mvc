
using MVCWEB.Infrastructe.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//api desteği geldi controllers ile -- presentation kaydı
builder.Services.AddControllers()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


// extensionsdan geldi
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureIdentity();

builder.Services.ConfigureSession();


builder.Services.ConfigureRepositoryRegistration();
builder.Services.ConfigureServiceRegistration();

builder.Services.ConfigureRouting();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.ConfigureApplicationCookie();

// adding HttpClient -- api bilgi çekme
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // dinamik alır {0} ile -- extensionsın altında bu bunu taşı diğer klosor altındaki yere öyle dene sonra
    app.UseStatusCodePagesWithRedirects("/Error/{0}");
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
// wwwroot eklendir
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

// bu ikisi şart -- routing ile endpointler arasında olmak zorunda
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name:"Admin",
        areaName:"Admin",
        pattern:"Admin/{controller=Dashboard}/{action=Index}/{id?}"
    );
    
    endpoints.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}");

    endpoints.MapRazorPages();

    // api desteği aldı
    endpoints.MapControllers();
});


app.ConfigureAndCheckMigration();
app.ConfigureLocalization();
app.ConfigureDefaultAdminUser();

app.Run();