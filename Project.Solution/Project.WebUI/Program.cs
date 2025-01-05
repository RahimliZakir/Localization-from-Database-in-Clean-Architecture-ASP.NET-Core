using Project.Infrastructure;
using Project.WebUI;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;
services.AddWebServices();
builder.AddInfrastructureServices();

WebApplication app = builder.Build();
builder.UseWebServices();
await app.UseInfrastructureServices();

app.Run();
