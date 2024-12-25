WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;
services.AddControllersWithViews();

WebApplication app = builder.Build();
IWebHostEnvironment env = builder.Environment;
if (env.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.MapGet("/", () => "Hello World!");

app.Run();
