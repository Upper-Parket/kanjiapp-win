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
            Navigator?.OpenMainView();
        }

        public void StartWithN4()
        {
            Navigator?.OpenMainView();
        }

        public void StartWithN3()
        {
            Navigator?.OpenMainView();
        }

        public void StartWithN2()
        {
            Navigator?.OpenMainView();
        }

        public void StartWithN1()
        {
            Navigator?.OpenMainView();
        }

        public void GoToHowManyYears()
        {
            Navigator?.PresentView(new HowManyYearsViewModel(Navigator));
        }
    }
}