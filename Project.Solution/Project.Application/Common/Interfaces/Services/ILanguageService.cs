using Project.Domain.Entities;

namespace Project.Application.Common.Interfaces.Services
{
    public interface ILanguageService
    {
        Task<IEnumerable<Language>> GetLanguages();
        Task<Language?> GetLanguageByCulture(string culture);
    }
}
