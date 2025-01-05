using Microsoft.AspNetCore.Mvc.Infrastructure;
using Project.Application.Common.Interfaces.Services;

namespace Project.WebUI.Extensions
{
    public class LocalizationHelper(IActionContextAccessor ctx, ILocalizationService localizationService)
    {
        readonly IActionContextAccessor ctx = ctx;
        readonly ILocalizationService localizationService = localizationService;

        async public Task<string?> Translate(string text)
        {
            bool result = ctx.ActionContext.HttpContext.Request.Cookies.TryGetValue("lang", out string langCultureCookie);

            return await localizationService.GetTranslation(text, result ? langCultureCookie : string.Empty);
        }
    }
}
