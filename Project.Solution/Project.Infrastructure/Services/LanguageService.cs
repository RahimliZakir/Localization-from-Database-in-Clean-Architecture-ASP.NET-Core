using Microsoft.EntityFrameworkCore;
using Project.Application.Common.Interfaces.Services;
using Project.Domain.Entities;
using Project.Infrastructure.Data;

namespace Project.Infrastructure.Services
{
    public class LanguageService(LocalizationDbContext db) : ILanguageService
    {
        readonly LocalizationDbContext db = db;

        async public Task<IEnumerable<Language>> GetLanguages()
        {
            return await db.Languages.ToListAsync();
        }

        async public Task<Language?> GetLanguageByCulture(string culture)
        {
            return await db.Languages.FirstOrDefaultAsync(x => string.Equals(x.Culture, culture, StringComparison.OrdinalIgnoreCase));
        }
    }
}
