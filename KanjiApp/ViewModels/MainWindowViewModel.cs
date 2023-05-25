using System.IO;
using KanjiApp.Onboarding.ViewModels;
using KanjiApp.Utils;
using ReactiveUI;

namespace KanjiApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, INavigator
    {
        private ViewModelBase _content;

        public ViewModelBase Content
        {
            get => _content;
            set => this.RaiseAndSetIfChanged(ref _content, value);
        }

        public MainWindowViewModel(string settingsFile) : base(null)
        {
            Content = File.Exists(settingsFile)
                ? new MainPageViewModel(this)
                : new HelloViewModel(this);
        }

        public void PresentView(ViewModelBase viewModelBase)
        {
            Content = viewModelBase;
        }

        public void OpenMainView()
        {
            Content = new MainPageViewModel(this);
        }
    }
}