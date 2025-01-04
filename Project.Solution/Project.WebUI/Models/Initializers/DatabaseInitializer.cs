using Microsoft.EntityFrameworkCore;
using Project.WebUI.Models.DataContexts;

namespace Project.WebUI.Models.Initializers
{
    public static class DatabaseInitializer
    {
        async static public Task UseDatabaseInitializer(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateAsyncScope();
            LocalizationDbContext db = scope.ServiceProvider.GetRequiredService<LocalizationDbContext>();

            if (!await db.Languages.AnyAsync())
            {
                await db.Languages.AddAsync(new()
                {
                    Name = "Azerbaijani",
                    CultureInfo = "az-AZ"
                });

                await db.Languages.AddAsync(new()
                {
                    Name = "English",
                    CultureInfo = "en-US"
                });

                await db.Languages.AddAsync(new()
                {
                    Name = "Russian",
                    CultureInfo = "ru-RU"
                });

                await db.SaveChangesAsync();
            }


            //db.Database.EnsureCreated();
        }
    }
}
