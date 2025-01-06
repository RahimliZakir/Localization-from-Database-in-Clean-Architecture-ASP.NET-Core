using Project.Infrastructure;
using Project.WebUI;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IConfiguration conf = builder.Configuration;

IServiceCollection services = builder.Services;
services.AddWebServices();
services.AddInfrastructureServices(conf);

WebApplication app = builder.Build();
IWebHostEnvironment env = builder.Environment;
app.UseWebServices(env);
await app.UseInfrastructureServices();

app.Run();
