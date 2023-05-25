namespace KanjiApp.PathHelper.Paths
{
    internal class WindowsPathFinder : IPathFinder
    {
        private readonly string _localAppData;

        public WindowsPathFinder()
        {
            _localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        }

        public string SettingsFile =>
            Path.Combine(_localAppData, WellKnownPaths.KanjiAppFolder, WellKnownPaths.SettingsFile);
    }
}