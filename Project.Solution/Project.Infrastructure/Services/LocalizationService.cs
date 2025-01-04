using Microsoft.EntityFrameworkCore;
using Project.Application.Common.Interfaces.Services;
using Project.Domain.Entities;
using Project.Infrastructure.Data;

namespace Project.Infrastructure.Services
{
    public class LocalizationService(LocalizationDbContext db) : ILocalizationService
    {
        readonly LocalizationDbContext db = db;

        async public Task<Translation?> GetTranslation(string resourceKey, int languageId)
        {
            return await db.Translations
                           .Include(x => x.Resource)
                           .FirstOrDefaultAsync(x => string.Equals(x.Resource.Name, resourceKey, StringComparison.OrdinalIgnoreCase)
                                                && x.LanguageId == languageId);
        }
    }
}
