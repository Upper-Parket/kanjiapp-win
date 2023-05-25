namespace KanjiApp.PathHelper.Paths
{
    internal class NixPathFinder : IPathFinder
    {
        public string SettingsFile => Path.Combine(Etc, WellKnownPaths.KanjiAppFolder, WellKnownPaths.SettingsFile);

        private const string Etc = "/etc";
    }
}