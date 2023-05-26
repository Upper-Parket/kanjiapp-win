using KanjiApp.Constants;
using KanjiApp.UserSettingsHelper;
using KanjiApp.Utils;
using KanjiApp.ViewModels;

namespace KanjiApp.Onboarding.ViewModels
{
    public class HelloViewModel : ViewModelBase
    {
        public HelloViewModel(INavigator? navigator) : base(navigator)
        {
        }

        public HelloViewModel() : this(null)
        {
        }

        public void GoToNextView()
        {
            Navigator?.PresentView(new LevelQuestionViewModel(Navigator));
        }

        public void SkipOnboarding()
        {
            SettingsInstance.CreateNew(SetNames.N5);
            Navigator?.OpenMainView();
        }
    }
}