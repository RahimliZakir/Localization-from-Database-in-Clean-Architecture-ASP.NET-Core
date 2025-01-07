using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project.Domain.Enums;

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
                    Abbr = "AZ",
                    Culture = "az-AZ"
                });

                await db.Languages.AddAsync(new()
                {
                    Name = "English",
                    Abbr = "EN",
                    Culture = "en-US"
                });

                await db.Languages.AddAsync(new()
                {
                    Name = "Russian",
                    Abbr = "RU",
                    Culture = "ru-RU"
                });

                await db.SaveChangesAsync();
            }

            if (!await db.Resources.AnyAsync())
            {
                await db.Resources.AddAsync(new()
                {
                    ApplicationType = ApplicationType.MVCApp,
                    Value = "welcome"
                });

                await db.Resources.AddAsync(new()
                {
                    ApplicationType = ApplicationType.MVCApp,
                    Value = "home"
                });

                await db.Resources.AddAsync(new()
                {
                    ApplicationType = ApplicationType.MVCApp,
                    Value = "contact"
                });

                await db.SaveChangesAsync();
            }

            if (!await db.Translations.AnyAsync())
            {
                await db.Translations.AddAsync(new()
                {
                    LanguageId = 1,
                    ResourceId = 1,
                    Value = "Xoş gəlmişsiniz!"
                });

                await db.Translations.AddAsync(new()
                {
                    LanguageId = 2,
                    ResourceId = 1,
                    Value = "Welcome!"
                });

                await db.Translations.AddAsync(new()
                {
                    LanguageId = 3,
                    ResourceId = 1,
                    Value = "Добро пожаловать!"
                });

                await db.SaveChangesAsync();
            }
        }
    }
}
