using Microsoft.EntityFrameworkCore;
using Project.WebUI.Models.DataContexts;
using Project.WebUI.Models.Initializers;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IConfiguration conf = builder.Configuration;

IServiceCollection services = builder.Services;
services.AddControllersWithViews();

services.AddDbContext<LocalizationDbContext>(cfg =>
{
    cfg.UseSqlServer(conf.GetConnectionString("cString"));
});

WebApplication app = builder.Build();
IWebHostEnvironment env = builder.Environment;
if (env.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.UseStaticFiles();

await app.UseDatabaseInitializer();

app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();
