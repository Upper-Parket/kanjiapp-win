using KanjiApp.Utils;
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

        public MainPageViewModel(INavigator? navigator) : base(navigator)
        {
            _currentSet = "N7";
        }

        public MainPageViewModel() : this(null)
        {
        }

        public void OpenQuiz()
        {
            Navigator?.PresentView(new QuizViewModel(Navigator));
        }
        
        public void OpenGlossary()
        {
            Navigator?.PresentView(new GlossaryViewModel(Navigator));
        }

        public void OpenSettings()
        {
            Navigator?.PresentView(new SettingsViewModel(Navigator));
        }
    }
}