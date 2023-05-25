using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using KanjiApp.PathHelper.Paths;
using KanjiApp.ViewModels;
using KanjiApp.Views;

namespace KanjiApp
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var settingsFile = PathFinder.SettingsFile;
                
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(settingsFile),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}