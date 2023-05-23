using KanjiApp.Utils;
using ReactiveUI;

namespace KanjiApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private string _currentSet;

        public string CurrentSet
        {
            get => $"Current set: {_currentSet}";
            set => this.RaiseAndSetIfChanged(ref _currentSet, value);
        }

        public MainPageViewModel(INavigator navigator)
        {
            _navigator = navigator;
            _currentSet = "N7";
        }

        public void OpenGlossary()
        {
            _navigator.PresentView(new GlossaryViewModel(_navigator));
        }
    }
}