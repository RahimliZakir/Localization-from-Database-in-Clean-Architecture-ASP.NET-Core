﻿using Microsoft.EntityFrameworkCore;
using Project.Application.Common.Interfaces.Services;
using Project.Domain.Entities;
using Project.Infrastructure.Data;

namespace Project.Infrastructure.Services
{
    public class LocalizationService(LocalizationDbContext db) : ILocalizationService
    {
        readonly LocalizationDbContext db = db;

        async public Task<string?> GetTranslation(string resourceKey, string languageCulture)
        {
            var d = await db.Translations.FirstOrDefaultAsync();
            var s = await db.Translations
                           .Include(x => x.Language)
                           .Include(x => x.Resource)
                           .FirstOrDefaultAsync(x => x.Resource.Value.Equals(resourceKey)
                                                && x.Language.Culture.Equals(languageCulture));

            return await db.Translations
                           .Include(x => x.Language)
                           .Include(x => x.Resource)
                           .FirstOrDefaultAsync(x => string.Equals(x.Resource.Value, resourceKey)
                                                && string.Equals(x.Language.Culture, languageCulture)) is Translation translation ? translation.Value : null;
        }
    }
}
