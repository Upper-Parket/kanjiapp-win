using KanjiApp.Constants;
using KanjiApp.UserSettingsHelper;
using KanjiApp.Utils;
using KanjiApp.ViewModels;
using ReactiveUI;

namespace KanjiApp.Onboarding.ViewModels
{
    public class HowManyYearsViewModel : ViewModelBase
    {
        private double _sliderValue;

        public double SliderValue
        {
            get => _sliderValue;
            set => this.RaiseAndSetIfChanged(ref _sliderValue, value);
        }

        public HowManyYearsViewModel(INavigator? navigator) : base(navigator)
        {
        }

        public HowManyYearsViewModel() : this(null)
        {
        }

        public void GoToMainView()
        {
            var setName = SliderValue switch
            {
                <= 1 => SetNames.N5,
                <= 2 => SetNames.N4,
                <= 4 => SetNames.N3,
                <= 6 => SetNames.N2,
                _ => SetNames.N1
            };
            SettingsInstance.CreateNew(setName);


            Navigator?.OpenMainView();
        }
    }
}