using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Project.Infrastructure.Data
{
    public class LocalizationDatabaseInitializer(LocalizationDbContext db, ILogger<LocalizationDatabaseInitializer> logger)
    {
        readonly LocalizationDbContext db = db;
        readonly ILogger<LocalizationDatabaseInitializer> logger = logger;

        public async Task InitializeAsync()
        {
            try
            {
                await db.Database.EnsureCreatedAsync();
                await db.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }

        async public Task SeedDataAsync()
        {
            try
            {
                await TrySeedDataAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        async public Task TrySeedDataAsync()
        {
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
        }
    }
}
