namespace KanjiApp.PathHelper.Paths
{
    internal class WindowsPathFinder : IPathFinder
    {
        private readonly string _localAppData;
        private readonly string _currentDirectory;

        public WindowsPathFinder()
        {
            _localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            _currentDirectory = Directory.GetCurrentDirectory();
        }

        public string SettingsFile =>
            Path.Combine(_localAppData, WellKnownPaths.KanjiAppFolder, WellKnownPaths.SettingsFile);

        public string N5SetFile => Path.Combine(_currentDirectory, WellKnownPaths.DataFolder, WellKnownPaths.N5File);
        public string N4SetFile => Path.Combine(_currentDirectory, WellKnownPaths.DataFolder, WellKnownPaths.N4File);
        public string N3SetFile => Path.Combine(_currentDirectory, WellKnownPaths.DataFolder, WellKnownPaths.N3File);
        public string N2SetFile => Path.Combine(_currentDirectory, WellKnownPaths.DataFolder, WellKnownPaths.N2File);
    }
}