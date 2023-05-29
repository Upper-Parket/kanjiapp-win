namespace KanjiApp.PathHelper.Paths
{
    internal interface IPathFinder
    {
        string SettingsFile { get; }
        string N5SetFile { get; }
        string N4SetFile { get; }
        string N3SetFile { get; }
        string N2SetFile { get; }
    }
}