using KanjiApp.Utils;
using ReactiveUI;

namespace KanjiApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigator? _navigator;
        private string _currentSet;

        public string CurrentSet
        {
            get => $"Current set: {_currentSet}";
            set => this.RaiseAndSetIfChanged(ref _currentSet, value);
        }

        public MainPageViewModel(INavigator? navigator)
        {
            _navigator = navigator;
            _currentSet = "N7";
        }

        public MainPageViewModel() : this(null)
        {
        }

        public void OpenQuiz()
        {
            _navigator?.PresentView(new QuizViewModel(_navigator));
        }
        
        public void OpenGlossary()
        {
            _navigator?.PresentView(new GlossaryViewModel(_navigator));
        }

        public void OpenSettings()
        {
            _navigator?.PresentView(new SettingsViewModel(_navigator));
        }
    }
}