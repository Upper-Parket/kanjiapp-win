using System;
using System.Runtime.InteropServices;

namespace KanjiApp.PathHelper.Paths
{
    public static class PathFinder
    {
        private static readonly IPathFinder _pathFinder;

        public static string SettingsFile => _pathFinder.SettingsFile;
        public static string N5SetFile => _pathFinder.N5SetFile;
        public static string N4SetFile => _pathFinder.N4SetFile;
        public static string N3SetFile => _pathFinder.N3SetFile;
        public static string N2SetFile => _pathFinder.N2SetFile;

        static PathFinder()
        {
            _pathFinder = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? new WindowsPathFinder()
                : new NixPathFinder();
        }
    }
}