using Project.Application.Common.Interfaces.Services;

namespace Project.WebUI.Extensions
{
    public static partial class Extension
    {
        async static public Task<string?> Translate(this HttpContext httpContext, string text)
        {
            using AsyncServiceScope scope = httpContext.RequestServices.CreateAsyncScope();
            ILocalizationService localizationService = scope.ServiceProvider.GetRequiredService<ILocalizationService>();
            bool result = httpContext.Request.Cookies.TryGetValue("lang", out string langCultureCookie);

            return await localizationService.GetTranslation(text, result ? langCultureCookie : null);
        }
    }
}
