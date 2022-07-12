using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Eqwel.AppSettings
{
    public static class Setting
    {
        public enum AppPrefrences
        {
            AppTheme,
            Mode
        }

        public enum Theme
        {
            LightTheme,
            DarkTheme
        }

        public static string GetSetting(AppPrefrences prefrence)
        {
            bool hasKey = Preferences.ContainsKey(key: Helpers.EnumHelper.ConvertToString(eff: prefrence));

            return hasKey ? Preferences.Get(key: Helpers.EnumHelper.ConvertToString(prefrence), defaultValue: null) : null;
        }

        public static void AddSetting(AppPrefrences prefrence, string setting)
        {
            Preferences.Set(key: Helpers.EnumHelper.ConvertToString(prefrence), value: setting);
        }

        public static async Task<string> GetSecureSetting(AppPrefrences prefrence)
        {
            return await SecureStorage.GetAsync(key: Helpers.EnumHelper.ConvertToString(eff: prefrence));
        }

        public static void RemoveSecureSetting(AppPrefrences prefrence)
        {
            _ = SecureStorage.Remove(key: Helpers.EnumHelper.ConvertToString(eff: prefrence));
        }

        public static void ClearSecureSorage()
        {
            SecureStorage.RemoveAll();
        }
    }
}
