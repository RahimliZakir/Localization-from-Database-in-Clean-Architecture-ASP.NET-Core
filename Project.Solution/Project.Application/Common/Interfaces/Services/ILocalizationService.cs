using Project.Domain.Entities;

namespace Project.Application.Common.Interfaces.Services
{
    public interface ILocalizationService
    {
        Task<string?> GetTranslation(string resourceKey, string languageCulture);
    }
}
