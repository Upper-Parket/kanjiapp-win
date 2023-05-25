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
            Navigator?.OpenMainView();
        }
    }
}