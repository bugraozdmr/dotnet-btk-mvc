using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace MVCWEB.Extensions;

public static class CustomErrorPages
{
    public static void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.UseStatusCodePagesWithReExecute("/Error/{0}");

        app.UseMvc(routes =>
        {
            routes.MapRoute(
                name: "error",
                template: "Error/{statusCode}",
                defaults: new { controller = "Error", action = "HandleError" }
            );

            // Diğer route'ları ekleyin...
        });
    }

}