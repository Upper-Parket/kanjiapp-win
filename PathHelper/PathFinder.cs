using System;
using System.Runtime.InteropServices;

namespace KanjiApp.PathHelper.Paths
{
    public static class PathFinder
    {
        private static readonly IPathFinder _pathFinder;

        public static string SettingsFile => _pathFinder.SettingsFile;

        static PathFinder()
        {
            _pathFinder = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? new WindowsPathFinder()
                : new NixPathFinder();
        }
    }
}