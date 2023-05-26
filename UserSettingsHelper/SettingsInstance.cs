namespace KanjiApp.UserSettingsHelper
{
    public static class SettingsInstance
    {
        private static UserSettings? _userSettings;

        public static UserSettings UserSettings => _userSettings ??= Initialize();

        private static UserSettings Initialize()
        {
            return UserSettings.GetDemo();
        }

        public static void CreateNew(string setName)
        {
            _userSettings = UserSettings.CreateNew(setName);
        }

        public static void Save(UserSettings settings)
        {
            _userSettings = settings;
        }
    }
}