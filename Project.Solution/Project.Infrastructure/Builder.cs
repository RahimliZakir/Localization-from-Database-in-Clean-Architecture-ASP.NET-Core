using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project.Infrastructure.Data;
using Project.Infrastructure.Extensions;

namespace Project.Infrastructure
{
    public static class Builder
    {
        public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
        {
            IConfiguration conf = builder.Configuration;
            IServiceCollection services = builder.Services;

            services.AddDbContext<LocalizationDbContext>(cfg =>
            {
                cfg.UseSqlServer(conf.GetConnectionString("cString"));
            });

            services.AddScoped<LocalizationDatabaseInitializer>();
        }

        async static public Task UseInfrastructureServices(this IApplicationBuilder app)
        {
            await app.InitializeDatabaseAsync();
        }
    }
}
