using Project.Domain.Entities;

namespace Project.WebUI.Interfaces
{
    public interface ILanguageService
    {
        IEnumerable<Language> GetLanguages();
        Language GetLanguageByCulture(string culture);
    }
}
