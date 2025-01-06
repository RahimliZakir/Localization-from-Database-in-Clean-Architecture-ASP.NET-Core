using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Application.Common.Interfaces.Services;
using Project.Infrastructure.Data;
using Project.Infrastructure.Extensions;
using Project.Infrastructure.Services;

namespace Project.Infrastructure
{
    public static class Builder
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration conf)
        {
            services.AddDbContext<LocalizationDbContext>(cfg =>
            {
                cfg.UseSqlServer(conf.GetConnectionString("cString"));
            });

            services.AddScoped<LocalizationDatabaseInitializer>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<ILocalizationService, LocalizationService>();
        }

        async static public Task UseInfrastructureServices(this IApplicationBuilder app)
        {
            await app.InitializeDatabaseAsync();
        }
    }
}
