using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Infrastructure.Data;
using Project.Infrastructure.Extensions;

namespace Project.Infrastructure
{
    public static class DependencyInjection
    {
        public static async Task AddInfrastructureServices(this WebApplicationBuilder builder)
        {
            IConfiguration conf = builder.Configuration;

            IServiceCollection services = builder.Services;

            services.AddDbContext<LocalizationDbContext>(cfg =>
            {
                cfg.UseSqlServer(conf.GetConnectionString("cString"));
            });

            services.AddScoped<LocalizationDatabaseInitializer>();
        }

        public static async Task UseInfrastructureServices(this WebApplicationBuilder builder)
        {
            WebApplication app = builder.Build();

            await app.InitializeDatabaseAsync();
        }
    }
}
