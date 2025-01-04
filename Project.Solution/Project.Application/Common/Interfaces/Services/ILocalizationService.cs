using Project.Domain.Entities;

namespace Project.Application.Common.Interfaces.Services
{
    public interface ILocalizationService
    {
        Task<Translation?> GetTranslation(string resourceKey, int languageId);
    }
}
