using UnityEngine.Localization.Settings;

namespace Jing.Tools.Localization
{
    public static class LocalizationManager
    {
        public static string GetLocalization(string table, string key)
        {
            return LocalizationSettings.StringDatabase.GetLocalizedString(table, key);
        }

        public static string Get(string table, string key)
        {
            var entry = LocalizationSettings.StringDatabase.GetTableEntry(table, key);
            if (entry.Entry != null)
                return entry.Entry.GetLocalizedString();
            else
                return $"<missing:{table}:{key}>";
        }

    }
}
