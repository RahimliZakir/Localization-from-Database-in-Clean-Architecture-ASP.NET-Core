using Project.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;
services.AddControllersWithViews();
builder.AddInfrastructureServices();

WebApplication app = builder.Build();
IWebHostEnvironment env = builder.Environment;
if (env.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.UseStaticFiles();

await app.UseInfrastructureServices();

app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();
