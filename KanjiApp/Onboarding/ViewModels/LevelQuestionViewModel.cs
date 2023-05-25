using KanjiApp.Utils;
using KanjiApp.ViewModels;

namespace KanjiApp.Onboarding.ViewModels
{
    public class LevelQuestionViewModel : ViewModelBase
    {
        public LevelQuestionViewModel(INavigator? navigator) : base(navigator)
        {
        }

        public LevelQuestionViewModel() : this(null)
        {
        }

        public void GoToWhatIsYourLevel()
        {
            Navigator?.PresentView(new WhatIsYourLevelViewModel(Navigator));
        }

        public void GoToHowManyYears()
        {
            Navigator?.PresentView(new HowManyYearsViewModel(Navigator));
        }

        public void GoToImNew()
        {
            Navigator?.OpenMainView();
        }
    }
}