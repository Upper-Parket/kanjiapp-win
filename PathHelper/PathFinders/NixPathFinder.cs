namespace KanjiApp.PathHelper.Paths
{
    internal class NixPathFinder : IPathFinder
    {
        private readonly string _currentDirectory;

        public NixPathFinder()
        {
            _currentDirectory = Directory.GetCurrentDirectory();
        }

        public string SettingsFile => Path.Combine(Etc, WellKnownPaths.KanjiAppFolder, WellKnownPaths.SettingsFile);

        public string N5SetFile => Path.Combine(_currentDirectory, WellKnownPaths.DataFolder, N5SetFile);
        public string N4SetFile => Path.Combine(_currentDirectory, WellKnownPaths.DataFolder, N4SetFile);
        public string N3SetFile => Path.Combine(_currentDirectory, WellKnownPaths.DataFolder, N3SetFile);
        public string N2SetFile => Path.Combine(_currentDirectory, WellKnownPaths.DataFolder, N2SetFile);

        private const string Etc = "/etc";
    }
}