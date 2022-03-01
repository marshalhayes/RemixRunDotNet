using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

WebApplication app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        "default",
        "{controller}/{action=Index}/{id?}");

    endpoints.MapControllers();
});

if (app.Environment.IsDevelopment())
{
    app.UseSpa(spaBuilder =>
    {
        spaBuilder.Options.PackageManagerCommand = "yarn";
        spaBuilder.Options.SourcePath = Path.GetFullPath("./RemixApp");

        spaBuilder.UseReactDevelopmentServer("dev");
    });
}

await app.RunAsync();