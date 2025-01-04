using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Project.Infrastructure.Data;

namespace Project.Infrastructure.Extensions
{
    public static class Extension
    {
        public static async Task InitializeDatabaseAsync(this IApplicationBuilder app)
        {
            using AsyncServiceScope scope = app.ApplicationServices.CreateAsyncScope();

            LocalizationDatabaseInitializer initializer = scope.ServiceProvider.GetRequiredService<LocalizationDatabaseInitializer>();

            await initializer.InitializeAsync();

            await initializer.SeedDataAsync();
        }
    }
}
