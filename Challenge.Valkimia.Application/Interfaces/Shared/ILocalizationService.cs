using Microsoft.Extensions.Localization;

namespace Challenge.Valkimia.Application
{
    public interface ILocalizationService
    {
        LocalizedString this[string key] { get; }

        LocalizedString GetLocalizedString(string key);
        LocalizedString GetCulturedLocalizedString(string key, string culture);

        string GetLocalizedString(string key, params string[] parameters);
    }
}
