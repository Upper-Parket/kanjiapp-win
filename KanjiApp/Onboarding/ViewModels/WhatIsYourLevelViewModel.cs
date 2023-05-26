using KanjiApp.Constants;
using KanjiApp.UserSettingsHelper;
using KanjiApp.Utils;
using KanjiApp.ViewModels;

namespace KanjiApp.Onboarding.ViewModels
{
    public class WhatIsYourLevelViewModel : ViewModelBase
    {
        public WhatIsYourLevelViewModel(INavigator? navigator) : base(navigator)
        {
        }

        public WhatIsYourLevelViewModel() : this(null)
        {
        }

        public void StartWithN5()
        {
            SettingsInstance.CreateNew(SetNames.N5);
            Navigator?.OpenMainView();
        }

        public void StartWithN4()
        {
            SettingsInstance.CreateNew(SetNames.N4);
            Navigator?.OpenMainView();
        }

        public void StartWithN3()
        {
            SettingsInstance.CreateNew(SetNames.N3);
            Navigator?.OpenMainView();
        }

        public void StartWithN2()
        {
            SettingsInstance.CreateNew(SetNames.N2);
            Navigator?.OpenMainView();
        }

        public void StartWithN1()
        {
            SettingsInstance.CreateNew(SetNames.N1);
            Navigator?.OpenMainView();
        }

        public void GoToHowManyYears()
        {
            Navigator?.PresentView(new HowManyYearsViewModel(Navigator));
        }
    }
}