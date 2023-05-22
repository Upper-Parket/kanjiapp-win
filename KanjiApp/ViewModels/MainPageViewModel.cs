using ReactiveUI;

namespace KanjiApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private string _currentSet;

        public string CurrentSet
        {
            get => $"Current set: {_currentSet}";
            set => this.RaiseAndSetIfChanged(ref _currentSet, value);
        }

        public MainPageViewModel()
        {
            _currentSet = "N7";
        }
    }
}