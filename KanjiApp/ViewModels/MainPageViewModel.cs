using KanjiApp.UserSettingsHelper;
using KanjiApp.Utils;
using ReactiveUI;

namespace KanjiApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public string CurrentSet => $"Current set: {SettingsInstance.UserSettings.CurrentSet}";

        public MainPageViewModel(INavigator? navigator) : base(navigator)
        {
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